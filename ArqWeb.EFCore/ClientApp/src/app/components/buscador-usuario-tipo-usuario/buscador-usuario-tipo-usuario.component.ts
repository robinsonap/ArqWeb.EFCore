import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'buscador-usuario-tipo-usuario',
  templateUrl: './buscador-usuario-tipo-usuario.component.html',
  styleUrls: ['./buscador-usuario-tipo-usuario.component.css']
})
export class BuscadorUsuarioTipoUsuarioComponent implements OnInit {

    tipoUsuarios: any;
    @Output() _tipoUsuario: EventEmitter<any>;

    constructor(private usuaService: UsuarioService) {
        this._tipoUsuario = new EventEmitter();
    }

    ngOnInit() {
        this.usuaService.getTipoUsuario().subscribe(data => this.tipoUsuarios = data);
    }

    filtrar(tipo) {
        this._tipoUsuario.emit(tipo);
    }
}
