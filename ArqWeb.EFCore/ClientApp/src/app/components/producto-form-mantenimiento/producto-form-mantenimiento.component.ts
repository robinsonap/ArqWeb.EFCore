import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators } from '@angular/forms'
import { ProductoServices } from '../../services/Producto.services'
import { CategoriaService } from '../../services/categoria.service'
import { ActivatedRoute, Router } from '@angular/router'
//  import { resolve, reject } from 'q';

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
    foto: any;

    //Router sirve para obtener métodos para navegar

    constructor(private productServices: ProductoServices, private categoriaServices: CategoriaService,
        private sActivatedR: ActivatedRoute, private sRoute: Router) {

        this.producto = new FormGroup({
            'ProductId': new FormControl("0"),
            'ProductName': new FormControl("", [Validators.required, Validators.maxLength(40)], this.validarNombre.bind(this)),
            'UnitPrice': new FormControl("0.00", [Validators.required]),
            'UnitsInStock': new FormControl("0", [Validators.required, this.noPuntoDecimal]),
            'SupplierId': new FormControl("", [Validators.required]),
            'CategoryId': new FormControl("", [Validators.required]),
            'foto': new FormControl(""),
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

                if (data.foto == null) {
                    this.foto = "";
                }
                else {
                    this.foto = data.foto;
                }
                
            });
        }
    }

    guardarDatos() {
        if (this.producto.valid == true) {

            this.producto.controls["foto"].setValue(this.foto);
            this.productServices.registrarProducto(this.producto.value).subscribe(data => {
                this.sRoute.navigate(["./mantenimiento-producto"])
            });
        }
    }

    noPuntoDecimal(control: FormControl) {
        if (control.value != null && control.value != "") {
            if ((<string>control.value.toString()).indexOf(".") > -1) {
                // Es porque SI existe ---> indexOf(".")> -1
                return { puntoDecimal: true }
            }
        }
        return null;
    }

    validarNombre(control: FormControl) {
        var promesa = new Promise((resolve, reject) => {
            if (control.value != "" && control.value != null) {
                this.productServices.validarNombre(
                    this.producto.controls["ProductId"].value, this.producto.controls["ProductName"].value).
                    subscribe(data => {
                        if (data == 1) {
                            resolve({ yaExiste: true });
                        }
                        else
                            resolve(null);
                    });
            }
        });

        return promesa;
    }

    changeFoto() {
        // Para que reconozca que es un elemento HTML (por defecto el document.getElementById puede tener problemas)
        var file = (<HTMLInputElement>document.getElementById("fupFoto")).files[0];
        var fileReader = new FileReader();
        
        fileReader.onloadend = () => {
            //Saca el archivo como bit 64
            this.foto = fileReader.result;
        }

        fileReader.readAsDataURL(file);
    }

}
