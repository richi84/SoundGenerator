import { Component, OnInit } from '@angular/core';
import { MusicGeneratorClientService } from '../music-generator-client.service';
import { SongOption } from '../song-option';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/timer';

@Component({
  selector: 'app-music-builder',
  templateUrl: './music-builder.component.html',
  styleUrls: ['./music-builder.component.css']
})
export class MusicBuilderComponent implements OnInit {

  id: number;
  percentage: number;
  subscription;

  // Song options:
  songOption: SongOption = {
    isTrack1Enabled: true,
    isTrack2Enabled: true,
    isTrack3Enabled: true
  };

  constructor(private musicGeneratorClinet: MusicGeneratorClientService) { }

  ngOnInit() {
  }

  onBuild() {
    this.percentage = 0;
    this.runBuild();
  }

  onNew() {
    this.id = null;
    this.percentage = 0;
  }

  runStatusUpdate(): void {
    this.musicGeneratorClinet.runStatusUpdate(this.id)
        .subscribe(returnedPercentage => {
          this.percentage = returnedPercentage;
          if (this.percentage === 100) {this.subscription.unsubscribe(); }
        });
  }

  runBuild(): void {
    this.musicGeneratorClinet.runBuild(this.songOption)
        .subscribe(returnedID => {
          this.id = returnedID;
          this.startUpdateTimer();
        });
  }

  startUpdateTimer(): void {
    const timer = Observable.timer(300, 300);
    this.subscription = timer.subscribe(() => {
        this.runStatusUpdate();
    });
  }
}
