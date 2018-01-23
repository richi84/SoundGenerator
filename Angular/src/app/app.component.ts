import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  info = false;

  gotoComposer() {
    this.info = false;
  }

  gotoInfo() {
    this.info =  true;
  }
}
