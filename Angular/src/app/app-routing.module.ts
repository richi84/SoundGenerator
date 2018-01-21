import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusicBuilderComponent }      from './music-builder/music-builder.component';

const routes: Routes = [
  { path: '', component: MusicBuilderComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
