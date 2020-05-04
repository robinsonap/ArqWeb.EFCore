import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router'
import { UsuarioService } from '../../services/usuario.service'

@Component({
  selector: 'grupo-usuario-form-mantenimiento',
  templateUrl: './grupo-usuario-form-mantenimiento.component.html',
  styleUrls: ['./grupo-usuario-form-mantenimiento.component.css']
})
export class GrupoUsuarioFormMantenimientoComponent implements OnInit {

    grupoUsuario: FormGroup;
    paginas: any;
    titulo: string;
    parametro: string;

    constructor(private usuaService: UsuarioService, private sActivatedR: ActivatedRoute, private sRoute: Router) {
        this.grupoUsuario = new FormGroup({
            'Co_grup': new FormControl("", [Validators.required, Validators.maxLength(8)]),
            'No_grup': new FormControl("", [Validators.required, Validators.maxLength(50)]),
            'Valores': new FormControl(""),
        });

        this.sActivatedR.params.subscribe(param => {
            this.parametro = param["id"];

            if (this.parametro == "nuevo") {
                this.titulo = "Agregando un nuevo tipo usuario"
            }
            else {
                this.titulo = "Editando un tipo usuario"
            }
        });

        this.usuaService.listarPaginasGrupoUsuario().subscribe(data => {
            this.paginas = data;
        });
    }

    ngOnInit() {
        //Aquí es recuperar información
        if (this.parametro != "nuevo") {
            this.usuaService.listarPaginasRecuperar(this.parametro).subscribe(data => {

                //console.log(data.co_grup);
                //console.log(data.no_grup);

                this.grupoUsuario.controls["Co_grup"].setValue(data.co_grup);
                this.grupoUsuario.controls["No_grup"].setValue(data.no_grup);

                var listaPag = data.listaPagina.map(p => p.idPagina);

                //Pintar la información
                setTimeout(() => {
                    //Luego de medio segundo se ejecuta la siguiente linea de códig (timeOut 500)
                    /////////////////////////////////////////////////////////////////////////////
                    var checks = document.getElementsByClassName("check");
                    var ncheck = checks.length;
                    var check;

                    for (var i = 0; i < ncheck; i++) {
                        check = checks[i];
                        var indice = listaPag.indexOf(check.name * 1);
                        // Si 'indice > - 1' significa que el valor SI EXISTE!!! 
                        if (indice > -1) {
                            check.checked = true;
                        }
                    }

                }, 500)

            });
        }
        else {

        }
    }

    guardarDatos() {
        if (this.grupoUsuario.valid == true) {
            this.usuaService.guardarDatosGrupoUsuario(this.grupoUsuario.value).subscribe(data => {
                // Luego de agregar vamos al mantenimiento usuario
                this.sRoute.navigate(["/mantenimiento-grupo-usuario"]);
            });
        }
    }

    verCheck() {
        var seleccionados = ""
        //Captura todo los elementos que tienen la clase 'check'
        var checks = document.getElementsByClassName("check");
        //console.log(checks);
        var check;
        //Contamos la cantida de check's seleccionados
        for (var i= 0; i < checks.length; i++) {
            check = checks[i];
            if (check.checked == true) {
                // += sirve para concatenar
                console.log(check.name)
                seleccionados += check.name;
                seleccionados += "$";
            }
        }

        //En el if eliminamos el último dolar que se contatenó obteniendo el último caracter con substring
        if (seleccionados != "") seleccionados = seleccionados.substring(0, seleccionados.length -1)

        console.log(seleccionados);

        this.grupoUsuario.controls["Valores"].setValue(seleccionados);
    }
}
