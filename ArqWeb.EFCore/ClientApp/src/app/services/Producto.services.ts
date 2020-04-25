import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'

@Injectable()

export class ProductoServices {

    urlBase: string = "";

    constructor(private http: Http, @Inject ('BASE_URL') baseUrl : string) {

        //urlBase tiene el nombre del dominio 
        this.urlBase = baseUrl;

    }

    public getProducto() {
        var urlFina = this.urlBase + "api/Producto/ListarProductos"
        console.log(urlFina);

        return this.http.get(urlFina).map(res => res.json())

    }

}
