import { Component, OnInit, Input } from '@angular/core';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'tabla-persona',
  templateUrl: './tabla-persona.component.html',
  styleUrls: ['./tabla-persona.component.css']
})
export class TablaPersonaComponent implements OnInit {

    @Input() empleados: any;
    cabeceras: string[]= ["Id Empleado", "Nombres y Apellidos", "Teléfono", "Año de nacimiento", "Ciudad"];

    constructor(private personaService : PersonaService) {

    }

    ngOnInit() {
        this.personaService.getPersonas().subscribe(data => this.empleados = data);
  }

}
