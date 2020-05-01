import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators } from '@angular/forms'
//Llamando al servicio persona.service
import { UsuarioService } from '../../services/usuario.service'
import { Router, ActivatedRoute } from '@angular/router'

@Component({
  selector: 'usuario-form-mantenimiento',
  templateUrl: './usuario-form-mantenimiento.component.html',
  styleUrls: ['./usuario-form-mantenimiento.component.css']
})
export class UsuarioFormMantenimientoComponent implements OnInit {

    usuario: FormGroup;
    titulo: string;
    parametro: string;
    grupoUsuario: any;
    ver: boolean = true;

    constructor(private usuaService: UsuarioService, private sRouter: Router, private sActivatedR: ActivatedRoute) {

        this.usuario = new FormGroup({
            'CoUsua': new FormControl("", [Validators.required, Validators.maxLength(8)], this.validarCodUsuario.bind(this)),
            'NoUsua': new FormControl("", [Validators.required, Validators.maxLength(50)]),
            'NoClav': new FormControl("", [Validators.required, Validators.maxLength(10)]),
            'NoClav2': new FormControl("", [Validators.required, Validators.maxLength(10), this.validarContraIguales.bind(this)]),
            'CoGrup': new FormControl("", [Validators.required]),
            'DeDireMail': new FormControl("", [Validators.required, Validators.maxLength(50), Validators.pattern("^[^@]+@[^@]+\.[a-zA-Z]{2,}$")]),
        });

        this.sActivatedR.params.subscribe(parametro => {
            this.parametro = parametro["id"];

            if (this.parametro == "nuevo") {
                this.titulo = "Agregando un nuevo Usuario"
                this.ver = true;
            }
            else {
                this.titulo = "Editando Usuario"
                this.ver = false;
                //Agregamos las siguientes lineas para desactivas las validaciones dato que estos campos están ocultos.
                this.usuario.controls["NoClav"].setValue("1");
                this.usuario.controls["NoClav2"].setValue("1");
            }
        });
    }

    ngOnInit() {
        this.usuaService.getTipoUsuario().subscribe(data => this.grupoUsuario = data);

        if (this.parametro != "nuevo") {
            this.usuaService.getBuscarUsuarioPorId(this.parametro).subscribe(data => {
                this.usuario.controls["CoUsua"].setValue(data.coUsua);
                this.usuario.controls["NoUsua"].setValue(data.noUsua);
                this.usuario.controls["NoClav"].setValue(data.noClav);
                this.usuario.controls["CoGrup"].setValue(data.coGrup);
                this.usuario.controls["DeDireMail"].setValue(data.deDireMail);
            });
        }
    }

    guardarDatos() {
        if (this.usuario.valid == true) {
            this.usuaService.registrarUsuario(this.usuario.value).subscribe(data => {
                this.sRouter.navigate(["./mantenimiento-usuario"])
            });
        }
    }

    validarContraIguales(control: FormControl) {
        if (control.value != "" && control.value != null) {
            if (this.usuario.controls["NoClav"].value != control.value) {
                return { noIguales: true };
            }
            else {
                return null;
            }
        }
    }

    validarCodUsuario(control: FormControl) {
        var promesa = new Promise((resolve, reject) => {
            if (control.value != "" && control.value != null) {
                this.usuaService.validarCodUsuario(
                    this.usuario.controls["CoUsua"].value).
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

}
