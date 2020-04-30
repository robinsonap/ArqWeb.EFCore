import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators } from '@angular/forms'
import { ProductoServices } from '../../services/Producto.services'
import { CategoriaService } from '../../services/categoria.service'
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'producto-form-mantenimiento',
  templateUrl: './producto-form-mantenimiento.component.html',
  styleUrls: ['./producto-form-mantenimiento.component.css']
})
export class ProductoFormMantenimientoComponent implements OnInit {

    producto: FormGroup;
    proveedor: any;
    categoria: any;
    titulo: string;
    parametro: string;

    constructor(private productServices: ProductoServices, private categoriaServices: CategoriaService, private sActivatedR: ActivatedRoute) {

        this.producto = new FormGroup({
            'ProductId': new FormControl("0"),
            'ProductName': new FormControl("", [Validators.required, Validators.maxLength(40)]),
            'UnitPrice': new FormControl("0.00", [Validators.required]),
            'UnitsInStock': new FormControl("0", [Validators.required]),
            'SupplierId': new FormControl("", [Validators.required]),
            'CategoryId': new FormControl("", [Validators.required]),
        });

        this.sActivatedR.params.subscribe(parametro => {
            this.parametro = parametro["id"];
            
            if (this.parametro == "nuevo") {
                this.titulo = "Agregando un nuevo producto"
            }
            else {
                this.titulo = "Editando un producto"
            }
        });
    }

    ngOnInit() {
        this.productServices.ListarProveedor().subscribe(data => this.proveedor = data);
        this.categoriaServices.getCategoria().subscribe(data => this.categoria = data);

        if (this.parametro != "nuevo") {
            this.productServices.obtenerProductoPorId(this.parametro).subscribe(data => {
                this.producto.controls["ProductId"].setValue(data.productId);
                this.producto.controls["ProductName"].setValue(data.productName);
                this.producto.controls["UnitPrice"].setValue(data.unitPrice);
                this.producto.controls["SupplierId"].setValue(data.supplierId);
                this.producto.controls["CategoryId"].setValue(data.categoryId);
                this.producto.controls["UnitsInStock"].setValue(data.unitsInStock);
            });
        }
    }



}
