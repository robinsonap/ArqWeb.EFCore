import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'

@Injectable()

export class ProductoServices {

    urlBase: string = "";
    urlFina: string = "";

    constructor(private http: Http, @Inject ('BASE_URL') baseUrl : string) {

        //urlBase tiene el nombre del dominio 
        this.urlBase = baseUrl;

    }

    public getProducto() {

        this.urlFina = this.urlBase + "api/Producto/ListarProductos"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())

    }

    public getFiltradoProductoNombre(dNombre) {

        this.urlFina = this.urlBase + "api/Producto/FiltrarProductoPorNombre/" + dNombre
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }
}
