import { Component, OnInit, Input } from '@angular/core';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'tabla-persona',
  templateUrl: './tabla-persona.component.html',
  styleUrls: ['./tabla-persona.component.css']
})
export class TablaPersonaComponent implements OnInit {

    @Input() empleados: any;
    @Input() isMantenimiento = false;
    p: number = 1;

    cabeceras: string[]= ["Id Empleado", "Nombres y Apellidos", "Teléfono", "Año de nacimiento", "Ciudad"];

    constructor(private personaService : PersonaService) {

    }

    ngOnInit() {
        this.personaService.getPersonas().subscribe(data => this.empleados = data);
    }

    eliminar(idPersona) {
        if (confirm("¿Desea eliminar el registro seleccionado?") == true) {
            //alert(idPersona)
            this.personaService.eliminarPersona(idPersona).subscribe(data => {
                this.personaService.getPersonas().subscribe(data => this.empleados = data);
            });
        }
        
    }

}
