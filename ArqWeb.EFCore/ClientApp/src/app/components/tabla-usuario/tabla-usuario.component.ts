import { Component, OnInit, Input } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service'

@Component({
  selector: 'tabla-usuario',
  templateUrl: './tabla-usuario.component.html',
  styleUrls: ['./tabla-usuario.component.css']
})
export class TablaUsuarioComponent implements OnInit {

    @Input() usuarios: any;
    cabeceras: string[] = ["Id Usuario", "Nombre Usuario", "Cod. Tipo Usuario", "Descrpcion Tipo Usuario"];

    constructor(private usuaService: UsuarioService) { }

    ngOnInit() {

        this.usuaService.getUsuario().subscribe(data => this.usuarios = data);

    }

}
