import { Component, OnInit, Input } from '@angular/core';
//Importamos el servicio
import {ProductoServices} from '../../services/Producto.services'

@Component({
  selector: 'tabla-productos',
  templateUrl: './tabla-productos.component.html',
  styleUrls: ['./tabla-productos.component.css']
})
export class TablaProductosComponent implements OnInit {

    // any = var
    @Input() productos_item: any;
    @Input() isMantenimiento = false;

    cabeceras: string[] = ["Id Producto", "Nombre Producto", "Id Categoria", "Nombre Categoría"]
    
    constructor(private producto: ProductoServices) {

    }

    //Todo lo que está en ngOnInit se ejecuta cuando carga la página.
    ngOnInit() {

        //console.log('OK_test');

        this.producto.getProducto().subscribe(
            data => this.productos_item = data
        );

        //console.log(resu);
  }

}
