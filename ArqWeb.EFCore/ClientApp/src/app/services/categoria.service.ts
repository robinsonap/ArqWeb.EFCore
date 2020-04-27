import { Injectable, Inject } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class CategoriaService {

    urlBase: string;
    urlFina: string;

    // Para capturar y obtener el dominio
    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.urlBase = baseUrl;
    }

    public getCategoria() {

        this.urlFina = this.urlBase + "api/Categoria/listarCategorias"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())

    }
}
