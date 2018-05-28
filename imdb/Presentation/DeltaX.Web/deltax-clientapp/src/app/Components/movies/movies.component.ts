import { Component, OnInit, ViewChild } from '@angular/core';
import { MoviesService } from '../../Services/movies.component.service';
import { AllMoviesData, Actor, Producer } from '../../Common/models/AllMoviesData';
import { Utilities } from '../../Common/utilities';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule, FormControl } from '@angular/forms';
import {ActorForm} from './child/actorform/actorform.component';
@Component({
  selector: 'app-movie',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css'],
})
export class MoviesComponent extends Utilities implements OnInit {
  @ViewChild('addEditModal') public addEditModal;
  allMovies: Array<AllMoviesData>;
  allActors: Array<Actor>;
  allProducers: Array<Producer>;
  movieInEdit: AllMoviesData;
  defaultMovie: AllMoviesData;
  movieForm: FormGroup;
  actorsList = [];
  producerList = [];
  selectedActors = [];
  selectedProducers = [];
  fileSelected: File;
  producerDropDown: {};
  isActorAdd: boolean;
  isProducerAdd: boolean;
  constructor(private movieService: MoviesService, private fb: FormBuilder) {
    super();
    this.isActorAdd = false;
    this.isProducerAdd=false;
    this.defaultMovie = {
      actors: [],
      movieID: -1,
      movieName: '',
      moviePoster: '',
      plot: '',
      producerID: -1,
      producerName: '',
      yearOfRelease: 1900,
      actorsCSV: ''
    }
    this.fileSelected = null;
    this.movieInEdit = this.defaultMovie;
    this.setDefaultForm();
    this.producerDropDown = {
      singleSelection: true,
      text: "Select Producer For this Movie",
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      enableSearchFilter: true
    };
  }
  ngOnInit() {
    this.movieService.getAllMovies().subscribe((data) => {
      this.allMovies = data;
    }, (err) => {
    });
    this.movieService.getAllActors().subscribe((data) => {
      this.allActors = data;
      this.actorsList = this.allActors.map(j => {
        return { "id": j.actorID, "itemName": j.actorName }
      })
    }, (err) => {
    });;
    this.movieService.getAllProducers().subscribe((data) => {
      this.allProducers = data;
      this.producerList = this.allProducers.map(j => {
        return { "id": j.producerID, "itemName": j.producerName }
      })
    }, (err) => {
    });;
  }
  setDefaultForm() {
    this.movieForm = this.fb.group({
      movieName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      plot: new FormControl("", [Validators.required, Validators.minLength(100)]),
      actors: new FormControl([], null),
      producers: new FormControl([], Validators.required),
      image: new FormControl(null, null),
    });
  }
  editModal(id: number) {
    this.movieInEdit = this.allMovies.filter(j => {
      return j.movieID == id;
    })[0];
    if (!super.isNullOrEmpty(this.movieInEdit)) {
      var actorsInMovie = this.movieInEdit.actors.map(a => a.actorID);
      this.selectedProducers = this.allProducers.filter(j => {
        return j.producerID == this.movieInEdit.producerID;
      }).map(j => { return { "id": j.producerID, "itemName": j.producerName } });
      if (!this.isNullOrEmpty(actorsInMovie) && actorsInMovie.length > 0) {
        this.selectedActors = this.allActors.filter(j => {
          return (actorsInMovie.indexOf(j.actorID) !== -1)
        }).map(j => {
          return { "id": j.actorID, "itemName": j.actorName }
        });
      }
      this.movieForm.patchValue({
        movieName: this.movieInEdit.movieName,
        plot: this.movieInEdit.plot
      });
      this.addEditModal.show();
    }
    else {
      alert("cannot edit Movie");
    }
  }
  closeModal() {
    this.addEditModal.hide();
    this.movieInEdit = this.defaultMovie;
    this.setDefaultForm();
  }
  saveData(val: any) {
    const form_data = new FormData();
    this.movieInEdit.movieName = val.movieName;
    this.movieInEdit.plot = val.plot;
    this.movieInEdit.actorsCSV = this.isNullOrEmpty(this.selectedActors) ? "" : this.selectedActors.map(j => j.id).toString();;
    var hasProducer = this.isNullOrEmpty(this.selectedProducers);
    this.movieInEdit.producerName = hasProducer ? "" : this.selectedProducers[0].itemName;
    this.movieInEdit.producerID = hasProducer ? -1 : this.selectedProducers[0].id;
    for (const key in this.movieInEdit) {
      if (this.movieInEdit.hasOwnProperty(key)) {
        form_data.append(key, this.movieInEdit[key]);
      }
    }
    form_data.append('poster', this.fileSelected);
    this.movieService.postMovie(form_data).subscribe((data) => {
      this.ngOnInit();
      this.closeModal();
    }, (err) => {
      alert(err);
      this.closeModal();
    });
  }

  fileEvent($event) {
    this.fileSelected = $event.target.files[0];
  }
  showProducerForm(){
    this.isProducerAdd = true;
  }
  showActorForm(){
    this.isActorAdd = true;
  }
}

