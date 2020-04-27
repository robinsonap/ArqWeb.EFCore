import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service'

@Component({
  selector: 'filtrado-usuario-tipo-usuario',
  templateUrl: './filtrado-usuario-tipo-usuario.component.html',
  styleUrls: ['./filtrado-usuario-tipo-usuario.component.css']
})
export class FiltradoUsuarioTipoUsuarioComponent implements OnInit {

    usua: any;

    constructor(private usuaServi: UsuarioService) { }

  ngOnInit() {
  }

    filtrar(tipoUsuario) {
        if (tipoUsuario == "") {
            this.usuaServi.getUsuario().subscribe(data => this.usua = data);
        }
        else {
            this.usuaServi.getFiltrarUsuarioPorTipo(tipoUsuario.value).subscribe(data => this.usua = data);
        }
    }
}
