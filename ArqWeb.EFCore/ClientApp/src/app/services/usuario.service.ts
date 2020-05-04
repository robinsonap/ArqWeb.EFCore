import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Router } from '@angular/router'

@Injectable()

export class UsuarioService {

    urlBase: string
    urlFina: string;

    // Para capturar y obtener el dominio
    constructor(private http: Http, @Inject("BASE_URL") url: string, private router: Router) {
        this.urlBase = url;
    }

    public getUsuario() {

        this.urlFina = this.urlBase + "api/Usuario/ListarUsuario"
        console.log(this.urlFina);

        //map conviente a Json
        return this.http.get(this.urlFina).map(res => res.json())

    }

    public getTipoUsuario() {
        this.urlFina = this.urlBase + "api/Usuario/ListadoTipoUsuario"
        console.log(this.urlFina);

        //map conviente a Json
        return this.http.get(this.urlFina).map(res => res.json())

    }

    public getFiltrarUsuarioPorTipo(_TiUsua) {
        this.urlFina = this.urlBase + "api/Usuario/FiltrarUsuarioPorTipo/" + _TiUsua
        console.log(this.urlFina);

        //map conviente a Json
        return this.http.get(this.urlFina).map(res => res.json())

    }

    public getBuscarUsuarioPorId(idUsuario) {
        this.urlFina = this.urlBase + "api/Usuario/BuscarUsuarioPorId/" + idUsuario
        console.log(this.urlFina);

        //map conviente a Json
        return this.http.get(this.urlFina).map(res => res.json())

    }

    public registrarUsuario(sUsuario) {

        this.urlFina = this.urlBase + "api/Usuario/registrarUsuario"
        console.log(this.urlFina);

        return this.http.post(this.urlFina, sUsuario).map(res => res.json())
    }

    public eliminarUsuario(idPersona) {

        this.urlFina = this.urlBase + "api/Usuario/eliminarUsuario/" + idPersona
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public validarCodUsuario(codUsuario) {
        this.urlFina = this.urlBase + "api/Usuario/validarCodUsuario/" + codUsuario
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public login(sUsuarioLogin) {
        this.urlFina = this.urlBase + "api/Usuario/login"
        console.log(this.urlFina);

        return this.http.post(this.urlFina, sUsuarioLogin).map(res => res.json())
    }

    public obtenerVariableSession() {
        this.urlFina = this.urlBase + "api/Usuario/obtenerVariableSession"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => {
            var data = res.json();
            var inf = data.sValor;

            if (inf == "") {
                this.router.navigate(["/pagina-error-login"])
                return false;
            }
            else {
                //// Hace match con la la variable next con el campo de URL de BD
                //var pagina = next["url"][0].path;
                //if (data.lista != null) {                
                //var paginas = data.lista.map(data => pagina.accion);
                //// indexOf -1 es si existe!!! 
                //if (paginas.indexOf(pagina) > -1 && paginas != "Login") {
                //    return true;
                //}
                //else {
                //    this.router.navigate(["/pagina-error-permiso"]);
                //}
                //}
                return true;
            }
        });
    }

    public obtenerSession() {
        this.urlFina = this.urlBase + "api/Usuario/obtenerVariableSession"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => {
            var data = res.json();
            var inf = data.sValor;

            if (inf == "") {
                return false;
            }
            else {
                return true;
            }
        });
    }

    public cerrarSession() {
        this.urlFina = this.urlBase + "api/Usuario/cerrarSession"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public listarPaginas() {
        this.urlFina = this.urlBase + "api/Usuario/listarPaginasPorUsua"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public listarGrupoUsuario() {
        this.urlFina = this.urlBase + "api/GrupoUsuario/listarGrupoUsuario"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public listarPaginasGrupoUsuario() {
        this.urlFina = this.urlBase + "api/GrupoUsuario/listarPaginasGrupoUsuario"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public listarPaginasRecuperar(coGrupoUsua) {
        this.urlFina = this.urlBase + "api/GrupoUsuario/listarPaginasRecuperar/" + coGrupoUsua
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public guardarDatosGrupoUsuario(sFormTipoUsuario) {
        this.urlFina = this.urlBase + "api/GrupoUsuario/guardarDatosGrupoUsuario"
        console.log(this.urlFina);

        return this.http.post(this.urlFina, sFormTipoUsuario).map(res => res.json())
    }

    public eliminarGrupoUsuario(codGrupoUsuario) {
        this.urlFina = this.urlBase + "api/GrupoUsuario/eliminarGrupoUsuario/" + codGrupoUsuario
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }
}
