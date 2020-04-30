import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validator, Validators } from '@angular/forms'
//Llamando al servicio persona.service
import { PersonaService } from '../../services/persona.service'
import { Router, ActivatedRoute } from '@angular/router'

@Component({
  selector: 'persona-form-mantenimiento',
  templateUrl: './persona-form-mantenimiento.component.html',
  styleUrls: ['./persona-form-mantenimiento.component.css']
})
export class PersonaFormMantenimientoComponent implements OnInit {

    // Nuevo
    // Editar

    empleado: FormGroup;
    titulo: string;
    parametro: string;

    constructor(private perService: PersonaService, private sRouter: Router, private sActivatedR: ActivatedRoute) {
        this.empleado = new FormGroup(
            {
                'EmployeeId': new FormControl("0"),
                'LastName': new FormControl("", [Validators.required, Validators.maxLength(20)]),
                'FirstName': new FormControl("", [Validators.required, Validators.maxLength(10)]),
                'HomePhone': new FormControl("", [Validators.required, Validators.maxLength(24)]),
                'City': new FormControl("", [Validators.required, Validators.maxLength(60)]),
                'BirthDate': new FormControl("", [Validators.required])
                //Validador para correos --->
                //'Email': new FormControl("", [Validators.required, Validators.maxLength(60), Validators.pattern("^[^@]+@[^@]+\.[a-zA-Z]{2,}$")],
            }
        );

        this.sActivatedR.params.subscribe(parametro => {
            this.parametro = parametro["id"];

            console.log(this.parametro)

            if (this.parametro == "nuevo") {
                this.titulo = "Agregando un nuevo registro"
            }
            else {
                this.titulo = "Editando un registro"
            }
        });
    }

    ngOnInit() {
        //Programar (Recupera la información)
        //Obtener los valores
        if (this.parametro != "nuevo") {
            this.perService.recuperarPersona(this.parametro).subscribe(data => {
                //Programar
                this.empleado.controls["EmployeeId"].setValue(data.employeeId)
                this.empleado.controls["LastName"].setValue(data.lastName)
                this.empleado.controls["FirstName"].setValue(data.firstName)
                this.empleado.controls["HomePhone"].setValue(data.homePhone)
                this.empleado.controls["City"].setValue(data.city)
                this.empleado.controls["BirthDate"].setValue(data.fechaCadena)
            });
        }
    }

    guardarDatos() {
        // El fórmulario siempre debe ser válido para registrar 
        if (this.empleado.valid == true) {

            //2009-10-12 --> 12/10/2009
            var fechaNacimiento = this.empleado.controls["BirthDate"].value.split("-");
            var anio = fechaNacimiento[0];
            var mes = fechaNacimiento[1];
            var dia = fechaNacimiento[2];

            this.empleado.controls["BirthDate"].setValue(mes + "/" + dia + "/" + anio);

            this.perService.agregarPersona(this.empleado.value).subscribe(data => { this.sRouter.navigate(["/mantenimiento-persona"]) });

            //// Vemos si es que aplica el servicio de agregar o editar
            //if (this.parametro == "nuevo") {
            //    this.perService.agregarPersona(this.empleado.value).subscribe(data => { this.sRouter.navigate(["/mantenimiento-persona"]) });
            //}
            //else {
            //    //Crearemos un servicio para editar persona
            //}
        }
    }

}
