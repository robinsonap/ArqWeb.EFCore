import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
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

import { HttpModule } from '@angular/http';
import { BuscadorProductoNombreComponent } from './components/buscador-producto-nombre/buscador-producto-nombre.component';
import { FiltradoProductoNombreComponent } from './components/filtrado-producto-nombre/filtrado-producto-nombre.component';
import { BuscadorProductoCategoriaComponent } from './components/buscador-producto-categoria/buscador-producto-categoria.component';
import { FiltradoProductoCagetoriaComponent } from './components/filtrado-producto-cagetoria/filtrado-producto-cagetoria.component';

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
    ],
    imports: [
        HttpModule,
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: 'filtradoProductoCategoria', component: FiltradoProductoCagetoriaComponent, pathMatch: 'full' },
            { path: 'filtradoProductoNombre', component: FiltradoProductoNombreComponent },
            { path: 'fetch-data', component: FetchDataComponent },
        ])
    ],
    providers: [ProductoServices, CategoriaService],
    bootstrap: [AppComponent]
})
export class AppModule { }
