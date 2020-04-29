import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
//Agregamos para poder trabajar con formularios
import { ReactiveFormsModule } from '@angular/forms'

import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TablaProductosComponent } from './components/tabla-productos/tabla-productos.component';

import { ProductoServices } from './services/Producto.services';
import { CategoriaService } from './services/categoria.service';
import { PersonaService } from './services/persona.service';
import { UsuarioService } from './services/usuario.service';

import { HttpModule } from '@angular/http';
import { BuscadorProductoNombreComponent } from './components/buscador-producto-nombre/buscador-producto-nombre.component';
import { FiltradoProductoNombreComponent } from './components/filtrado-producto-nombre/filtrado-producto-nombre.component';
import { BuscadorProductoCategoriaComponent } from './components/buscador-producto-categoria/buscador-producto-categoria.component';
import { FiltradoProductoCagetoriaComponent } from './components/filtrado-producto-cagetoria/filtrado-producto-cagetoria.component';
import { TablaPersonaComponent } from './components/tabla-persona/tabla-persona.component';
import { BuscadorPersonaNombreCompletoComponent } from './components/buscador-persona-nombre-completo/buscador-persona-nombre-completo.component';
import { FiltradoPersonaNombreCompletoComponent } from './components/filtrado-persona-nombre-completo/filtrado-persona-nombre-completo.component';
import { BuscadorUsuarioTipoUsuarioComponent } from './components/buscador-usuario-tipo-usuario/buscador-usuario-tipo-usuario.component';
import { FiltradoUsuarioTipoUsuarioComponent } from './components/filtrado-usuario-tipo-usuario/filtrado-usuario-tipo-usuario.component';
import { TablaUsuarioComponent } from './components/tabla-usuario/tabla-usuario.component';
import { MantenimientoPersonaComponent } from './components/mantenimiento-persona/mantenimiento-persona.component';
import { PersonaFormMantenimientoComponent } from './components/persona-form-mantenimiento/persona-form-mantenimiento.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        TablaProductosComponent,
        BuscadorProductoNombreComponent,
        FiltradoProductoNombreComponent,
        BuscadorProductoCategoriaComponent,
        FiltradoProductoCagetoriaComponent,
        TablaPersonaComponent,
        BuscadorPersonaNombreCompletoComponent,
        FiltradoPersonaNombreCompletoComponent,
        BuscadorUsuarioTipoUsuarioComponent,
        FiltradoUsuarioTipoUsuarioComponent,
        TablaUsuarioComponent,
        MantenimientoPersonaComponent,
        PersonaFormMantenimientoComponent,
    ],
    imports: [
        HttpModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: 'filtradoProductoCategoria', component: FiltradoProductoCagetoriaComponent, pathMatch: 'full' },
            { path: 'filtradoProductoNombre', component: FiltradoProductoNombreComponent },
            { path: 'filtradoPersonaNombreCompleto', component: FiltradoPersonaNombreCompletoComponent },
            { path: 'filtradoUsuarioPorTipo', component: FiltradoUsuarioTipoUsuarioComponent },
            { path: 'mantenimiento-persona', component: MantenimientoPersonaComponent },
            { path: 'mantenimiento-persona/:id', component: PersonaFormMantenimientoComponent },
        ])
    ],
    providers: [ProductoServices, CategoriaService, PersonaService, UsuarioService],
    bootstrap: [AppComponent]
})
export class AppModule { }
