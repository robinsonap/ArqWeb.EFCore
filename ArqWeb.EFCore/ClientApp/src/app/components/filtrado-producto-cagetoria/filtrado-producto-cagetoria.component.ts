import { Component, OnInit } from '@angular/core';
import { ProductoServices } from '../../services/Producto.services';

@Component({
  selector: 'filtrado-producto-cagetoria',
  templateUrl: './filtrado-producto-cagetoria.component.html',
  styleUrls: ['./filtrado-producto-cagetoria.component.css']
})
export class FiltradoProductoCagetoriaComponent implements OnInit {

    _productos: any;

    constructor(private _productoService: ProductoServices) {

    }

  ngOnInit() {
  }

    buscar(categoria) {

        if (categoria.value == "") {
            this._productoService.getProducto().subscribe(data => this._productos = data);
        }
        else {
            this._productoService.getFiltradoProductoPorCategoria(categoria.value).subscribe(data => this._productos = data);
        }

    }

    limpiar(categoria) {

        categoria.value = "";

        this._productoService.getProducto().subscribe(data => this._productos = data);

    }

}
