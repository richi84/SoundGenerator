import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { SongOption } from './song-option'

@Injectable()
export class MusicGeneratorClientService {

  private url='http://drachir.ch/rest/';
  //private url='http://localhost:8000/';

  constructor(private http: HttpClient) {}

  runStatusUpdate(id: number): Observable<number> {
    return this.http.get<number>(this.url+"state/"+id);
  }

  runBuild(songOption: SongOption): Observable<number> {
    return this.http.post<number>(this.url+"build", JSON.stringify(songOption), {headers:{'Content-Type': 'application/json'}})
  }


}
