import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'buscador-persona-nombre-completo',
  templateUrl: './buscador-persona-nombre-completo.component.html',
  styleUrls: ['./buscador-persona-nombre-completo.component.css']
})
export class BuscadorPersonaNombreCompletoComponent implements OnInit {

    @Output() buscarPorNombre: EventEmitter<any>;

    //En el constructor lo vamos a inicializar
    constructor() {
        this.buscarPorNombre = new EventEmitter();
    }

    ngOnInit() {

    }

    buscar(nombreCompleto) {
        this.buscarPorNombre.emit(nombreCompleto);
    }
}
