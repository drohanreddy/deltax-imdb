import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http'; 
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown/angular2-multiselect-dropdown';
 

import { AppComponent } from './app.component';
import { ActorComponent } from './Components/actor/actor.component';
import { MoviesComponent } from './Components/movies/movies.component';
import { ProducerComponent } from './Components/producer/producer.component';
import { MoviesService } from './Services/movies.component.service';
import { ActorForm } from './Components/movies/child/actorform/actorform.component';


const appRoutes: Routes = [
  { path: '', component: MoviesComponent },
  { path: 'actor/:id', component: ActorComponent },
  { path: 'producer/:id', component: ProducerComponent },
];
@NgModule({
  declarations: [
    AppComponent,
    ActorComponent,
    MoviesComponent,
    ProducerComponent,
    ActorForm
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MDBBootstrapModule.forRoot(),
    AngularMultiSelectModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    MoviesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
