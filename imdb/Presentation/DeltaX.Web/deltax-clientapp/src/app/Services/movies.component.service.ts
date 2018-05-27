import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';
import { AllMoviesData, Actor , Producer} from "../Common/models/AllMoviesData";

@Injectable()
export class MoviesService {
    constructor(private http: HttpClient) {
    }

    getAllMovies(): Observable<AllMoviesData[]>{
        return this.http.get<AllMoviesData[]>("http://localhost:60153/movies/getall");
    }
    getAllActors(): Observable<Actor[]>{
        return this.http.get<Actor[]>("http://localhost:60153/actors/getall");
    }
    getAllProducers(): Observable<Producer[]>{
        return this.http.get<Producer[]>("http://localhost:60153/producers/getall");
    }

    postMovie(data): Observable<boolean>{
        return this.http.post<boolean>("http://localhost:60153/movies/saveMovieData",data);
    }
}