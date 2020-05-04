import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MantenimientoGrupoUsuarioComponent } from './mantenimiento-grupo-usuario.component';

describe('MantenimientoGrupoUsuarioComponent', () => {
  let component: MantenimientoGrupoUsuarioComponent;
  let fixture: ComponentFixture<MantenimientoGrupoUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MantenimientoGrupoUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MantenimientoGrupoUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
