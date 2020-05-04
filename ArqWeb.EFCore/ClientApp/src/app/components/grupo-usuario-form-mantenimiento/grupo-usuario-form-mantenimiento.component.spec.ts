import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GrupoUsuarioFormMantenimientoComponent } from './grupo-usuario-form-mantenimiento.component';

describe('GrupoUsuarioFormMantenimientoComponent', () => {
  let component: GrupoUsuarioFormMantenimientoComponent;
  let fixture: ComponentFixture<GrupoUsuarioFormMantenimientoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GrupoUsuarioFormMantenimientoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GrupoUsuarioFormMantenimientoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
