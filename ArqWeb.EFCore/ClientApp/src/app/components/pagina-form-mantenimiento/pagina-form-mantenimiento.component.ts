import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators } from '@angular/forms'
//Llamando al servicio persona.service
import { PaginasService } from '../../services/paginas.service'
import { Router, ActivatedRoute } from '@angular/router'

@Component({
  selector: 'pagina-form-mantenimiento',
  templateUrl: './pagina-form-mantenimiento.component.html',
  styleUrls: ['./pagina-form-mantenimiento.component.css']
})
export class PaginaFormMantenimientoComponent implements OnInit {

    paginas: FormGroup;
    titulo: string;
    parametro: string;

    constructor(private sServicioPagina: PaginasService, private sRouter: Router, private sActivatedRoute: ActivatedRoute) {

        this.paginas = new FormGroup(
            {
                'IdPagina': new FormControl("0"),
                'Mensaje': new FormControl("", [Validators.required, Validators.maxLength(50)]),
                'Accion': new FormControl("", [Validators.required, Validators.maxLength(100)]),
            }
        );

        this.sActivatedRoute.params.subscribe(parametro => {
            this.parametro = parametro["id"];

            //console.log(this.parametro)

            if (this.parametro == "nuevo") {
                this.titulo = "Agregando un nuevo registro"
            }
            else {
                this.titulo = "Editando un registro"
            }
        });

    }

    ngOnInit() {
        //Programar (Recupera la información)
        //Obtener los valores
        if (this.parametro != "nuevo") {
            this.sServicioPagina.obtenerPaginaPorId(this.parametro).subscribe(json => {
                //Programar
                //console.log(json);

                this.paginas.controls["IdPagina"].setValue(json.idPagina);
                this.paginas.controls["Mensaje"].setValue(json.mensaje);
                this.paginas.controls["Accion"].setValue(json.accion);
            });
        }
    }

    guardarDatos() {
        // El fórmulario siempre debe ser válido para registrar 
        if (this.paginas.valid == true) {

            this.sServicioPagina.registrarPagina(this.paginas.value).subscribe(data => { this.sRouter.navigate(["/mantenimiento-pagina"]) });

        }
    }

}
