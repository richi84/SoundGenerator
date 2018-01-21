import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MusicBuilderComponent } from './music-builder.component';

describe('MusicBuilderComponent', () => {
  let component: MusicBuilderComponent;
  let fixture: ComponentFixture<MusicBuilderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MusicBuilderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MusicBuilderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
