import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators } from '@angular/forms'
import { PersonaService } from '../../services/persona.service'
import { Router } from '@angular/router'

@Component({
  selector: 'persona-form-mantenimiento',
  templateUrl: './persona-form-mantenimiento.component.html',
  styleUrls: ['./persona-form-mantenimiento.component.css']
})
export class PersonaFormMantenimientoComponent implements OnInit {

    empleado: FormGroup;

    constructor(private perService: PersonaService, private sRouter: Router) {
        this.empleado = new FormGroup(
            {
                'EmployeeId': new FormControl("0"),
                'LastName': new FormControl("", [Validators.required, Validators.maxLength(20)]),
                'FirstName': new FormControl("", [Validators.required, Validators.maxLength(10)]),
                'HomePhone': new FormControl("", [Validators.required, Validators.maxLength(24)]),
                'Address': new FormControl("", [Validators.required, Validators.maxLength(60)]),
                //Validador para correos --->
                //'Email': new FormControl("", [Validators.required, Validators.maxLength(60), Validators.pattern("^[^@]+@[^@]+\.[a-zA-Z]{2,}$")],
            }
        );
    }

    ngOnInit() {

    }

    guardarDatos() {

        if (this.empleado.valid == true) {

            this.perService.agregarPersona(this.empleado.value).subscribe(data => { this.sRouter.navigate(["/mantenimiento-persona"]) });

        }
    }

}
