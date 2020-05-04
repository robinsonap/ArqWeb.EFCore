import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { UsuarioService } from '../../services/usuario.service'
import { Router } from '@angular/router'

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    usuario: FormGroup;
    error: boolean = false;
    urlBase: string

    constructor(private usuarioService: UsuarioService, private router: Router, @Inject("BASE_URL") url: string) {

        this.urlBase = url;

        this.usuario = new FormGroup({
            'CoUsua': new FormControl("", [Validators.required, Validators.maxLength(8)]),
            'NoClav': new FormControl("", [Validators.required, Validators.maxLength(10)]),
        });
    }

    ngOnInit() {

    }

    login() {
        if (this.usuario.valid == true) {
            this.usuarioService.login(this.usuario.value).subscribe(data => {
                //console.log(data.coUsua);
                if (data.coUsua == "") {
                    //Error
                    this.error = true;
                }
                else {
                    //Ok
                    //this.router.navigate(["/componente-bienvenida"]);
                    // OJO no es muy recomendada usar de la siguiente forma
                    window.location.href = this.urlBase + "componente-bienvenida"
                    this.error = false;
                }
            });
        }
    }

}
