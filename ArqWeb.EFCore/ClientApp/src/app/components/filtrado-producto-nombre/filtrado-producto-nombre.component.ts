import { Component, OnInit } from '@angular/core';
import { ProductoServices } from '../../services/Producto.services';

@Component({
  selector: 'filtrado-producto-nombre',
  templateUrl: './filtrado-producto-nombre.component.html',
  styleUrls: ['./filtrado-producto-nombre.component.css']
})
export class FiltradoProductoNombreComponent implements OnInit {

    productos: any;

    constructor(private productoServices: ProductoServices) {

    }

    ngOnInit() {

    }

    filtrarDatos(nombre) {

        // productos = almacena resultado en esta variable
        // susbcribe extrae la data obtenida del servicio

        if (nombre.value == "") {
            this.productoServices.getProducto().subscribe(data => this.productos = data);
        }
        else {
            this.productoServices.getFiltradoProductoNombre(nombre.value).subscribe(data => this.productos = data);
        }
        
        //console.log(nombre);
        //console.log(nombre.value);
    }

    limpiar(nombre) {

        nombre.value = "";

        this.productoServices.getProducto().subscribe(data => this.productos = data);
    }

}
