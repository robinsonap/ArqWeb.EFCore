import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablaGrupoUsuarioComponent } from './tabla-grupo-usuario.component';

describe('TablaGrupoUsuarioComponent', () => {
  let component: TablaGrupoUsuarioComponent;
  let fixture: ComponentFixture<TablaGrupoUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablaGrupoUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablaGrupoUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
