import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router'
import { UsuarioService } from '../../services/usuario.service'

@Injectable()

export class SeguridadGuard implements CanActivate {

    constructor(private router: Router, private UsuaService: UsuarioService) {

    }
  canActivate(
    next: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

      //this.router.navigate(["pagina-error"])
      //return false;

      //netx --> Trae información de la URL

      return this.UsuaService.obtenerVariableSession();

  }
}
