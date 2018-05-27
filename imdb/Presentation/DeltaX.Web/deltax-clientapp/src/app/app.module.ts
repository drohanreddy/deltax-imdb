import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { AppComponent } from './app.component';
import { ActorComponent } from './Components/actor/actor.component';
import { MoviesComponent } from './Components/movies/movies.component';

const appRoutes: Routes = [
  { path: 'actor/:id', component: ActorComponent },
  { path: 'movies', component: MoviesComponent }
];
@NgModule({
  declarations: [
    AppComponent,
    ActorComponent,
    MoviesComponent
  ],
  imports: [
    BrowserModule,
    MDBBootstrapModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
