import { Component, OnInit, Input } from '@angular/core';
import { PaginasService } from '../../services/paginas.service';

@Component({
  selector: 'tabla-pagina',
  templateUrl: './tabla-pagina.component.html',
  styleUrls: ['./tabla-pagina.component.css']
})
export class TablaPaginaComponent implements OnInit {

    @Input() JsonPaginas: any;
    @Input() isMantenimiento = false;
    p: number = 1;

    cabeceras: string[] = ["Id Página", "Mensaje", "Acción"];


    constructor(private sPaginaServicio: PaginasService) {

    }

    ngOnInit() {
        this.sPaginaServicio.listarPaginas().subscribe(data => this.JsonPaginas = data);
    }

    eliminar(idPagina) {
        if (confirm("¿Desea eliminar el registro seleccionado?") == true) {
            //alert(idPersona)
            this.sPaginaServicio.eliminarPagina(idPagina).subscribe(data => {
                this.sPaginaServicio.listarPaginas().subscribe(data => this.JsonPaginas = data);
            });
        }

    }

}
