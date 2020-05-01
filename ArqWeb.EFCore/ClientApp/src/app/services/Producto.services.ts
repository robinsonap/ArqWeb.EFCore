import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'

@Injectable()

export class ProductoServices {

    urlBase: string = "";
    urlFina: string = "";

    // Para capturar y obtener el dominio
    constructor(private http: Http, @Inject ('BASE_URL') baseUrl : string) {

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

    public getFiltradoProductoPorCategoria(idCategoria) {

        this.urlFina = this.urlBase + "api/Categoria/FiltrarCategoriaPorNombre/" + idCategoria
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public obtenerProductoPorId(idProducto) {
        this.urlFina = this.urlBase + "api/Producto/obtenerProductoPorId/" + idProducto
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public ListarProveedor() {
        this.urlFina = this.urlBase + "api/Producto/ListarProveedor"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public eliminarProducto(idProducto) {
        this.urlFina = this.urlBase + "api/Producto/eliminarProducto/" + idProducto
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public registrarProducto(ProductoFormEntity) {
        this.urlFina = this.urlBase + "api/Producto/registrarProducto"
        console.log(this.urlFina);

        return this.http.post(this.urlFina, ProductoFormEntity).map(res => res.json())
    }

    public validarNombre(idProducto, nProducto) {
        this.urlFina = this.urlBase + "api/Producto/validarNombre/" + idProducto + "/" + nProducto
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }
}
