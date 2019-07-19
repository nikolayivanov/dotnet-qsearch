import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QsearchComponent } from './qsearch.component';

describe('QsearchComponent', () => {
  let component: QsearchComponent;
  let fixture: ComponentFixture<QsearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QsearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QsearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
