import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltradoProductoCagetoriaComponent } from './filtrado-producto-cagetoria.component';

describe('FiltradoProductoCagetoriaComponent', () => {
  let component: FiltradoProductoCagetoriaComponent;
  let fixture: ComponentFixture<FiltradoProductoCagetoriaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FiltradoProductoCagetoriaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltradoProductoCagetoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
