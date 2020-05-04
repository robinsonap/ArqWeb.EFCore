import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router'

@Injectable()

export class PaginasService {

    urlBase: string
    urlFina: string;

    constructor(private http: Http, @Inject("BASE_URL") url: string, private router: Router) {

        this.urlBase = url;
    }

    public listarPaginas() {
        this.urlFina = this.urlBase + "api/Pagina/listadoDePaginasMenu"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public obtenerPaginaPorId(idPagina) {
        this.urlFina = this.urlBase + "api/Pagina/obtenerPaginaPorId/" + idPagina
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public registrarPagina(sFormPagina) {
        this.urlFina = this.urlBase + "api/Pagina/registrarPagina"
        console.log(this.urlFina);

        return this.http.post(this.urlFina, sFormPagina).map(res => res.json())
    }

    public eliminarPagina(idPagina) {
        this.urlFina = this.urlBase + "api/Pagina/eliminarPagina/" + idPagina
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

}
