import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class UsuarioService {

    urlBase: string
    urlFina: string;

    // Para capturar y obtener el dominio
    constructor(private http: Http, @Inject("BASE_URL") url: string) {
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

}
