import { Component, OnInit } from '@angular/core';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'filtrado-persona-nombre-completo',
  templateUrl: './filtrado-persona-nombre-completo.component.html',
  styleUrls: ['./filtrado-persona-nombre-completo.component.css']
})
export class FiltradoPersonaNombreCompletoComponent implements OnInit {

    _empleados: any;

    constructor(private _personaService: PersonaService) {
    }

  ngOnInit() {
  }

    buscar(nombreCompleto) {
        //console.log(nombreCompleto);
        //console.log(nombreCompleto.value);
        this._personaService.getPersonaFiltro(nombreCompleto.value).subscribe(data => this._empleados = data);
    }

}
