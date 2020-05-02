import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../services/usuario.service'
import { Router } from '@angular/router'

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
    isExpanded = false;
    login: boolean = false;
    menus: any;

    constructor(private usuaService: UsuarioService, private router: Router) {

    }

    ngOnInit() {
        this.usuaService.obtenerSession().subscribe(data => {
            // Si data es true es porque estamos logeados
            if (data) {
                this.login = true;

                // Si el login es correcto verificamos accesos a los menús
                this.usuaService.listarPaginas().subscribe(data => {
                    this.menus = data;
                    //console.log(this.menus)
                });
            }
            else {
                this.login = false;
            }
        });
    }

    cerrarSession() {
        this.usuaService.cerrarSession().subscribe(data => {
            if (data == "OK") {
                this.login = false;
                this.router.navigate(["/login"]);
            }
            else {
                this.login = true;
                this.router.navigate(["/login"]);
            }
        });
    }

    collapse() {
      this.isExpanded = false;

    }


    toggle() {
      this.isExpanded = !this.isExpanded;

    }
 
}
