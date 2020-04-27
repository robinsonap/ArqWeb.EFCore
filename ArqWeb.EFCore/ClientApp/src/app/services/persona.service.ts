import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class PersonaService {

    urlBase: string
    urlFina: string;

    // Para capturar y obtener el dominio
    constructor(private http: Http, @Inject("BASE_URL") url: string) {
        this.urlBase = url;
    }

    /*----------------------------------------------------------------*/
    public getPersonas() {
        this.urlFina = this.urlBase + "api/Empleados/ListarEmpleados"
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())
    }

    public getPersonaFiltro(nombreCompleto) {

        this.urlFina = this.urlBase + "api/Empleados/ListarEmpleados/" + nombreCompleto
        console.log(this.urlFina);

        return this.http.get(this.urlFina).map(res => res.json())

    }

}
