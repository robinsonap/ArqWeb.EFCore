import { Component, OnInit, Input } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service'

@Component({
  selector: 'tabla-grupo-usuario',
  templateUrl: './tabla-grupo-usuario.component.html',
  styleUrls: ['./tabla-grupo-usuario.component.css']
})
export class TablaGrupoUsuarioComponent implements OnInit {

    grupoUsuario: any;
    @Input() isMantenimiento = false;
    cabeceras: string[] = ["Cod. Grupo", "Nombre Grupo"];

    constructor(private usuarioService: UsuarioService) {

    }

    ngOnInit() {
        this.usuarioService.listarGrupoUsuario().subscribe(data => {
            this.grupoUsuario = data;
        })
    }

    eliminar(codGrupo) {
        this.usuarioService.eliminarGrupoUsuario(codGrupo).subscribe(data => {
            this.usuarioService.listarGrupoUsuario().subscribe(data => {
                this.grupoUsuario = data;
            })
        });
    }

}
