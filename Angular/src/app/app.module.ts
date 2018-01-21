import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MusicGeneratorClientService } from './music-generator-client.service';
import { AppRoutingModule } from './/app-routing.module';
import { MusicBuilderComponent } from './music-builder/music-builder.component';


@NgModule({
  declarations: [
    AppComponent,
    MusicBuilderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [MusicGeneratorClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
