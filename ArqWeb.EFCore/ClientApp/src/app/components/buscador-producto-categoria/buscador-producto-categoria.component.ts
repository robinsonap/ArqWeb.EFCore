import { Component, OnInit } from '@angular/core';
import { CategoriaService } from '../../services/categoria.service';

@Component({
  selector: 'buscador-producto-categoria',
  templateUrl: './buscador-producto-categoria.component.html',
  styleUrls: ['./buscador-producto-categoria.component.css']
})
export class BuscadorProductoCategoriaComponent implements OnInit {

    _mcategorias: any;

    constructor(private categoriaServicio: CategoriaService) {
        this.categoriaServicio.getCategoria().subscribe(data => this._mcategorias = data);
    }

  ngOnInit() {
  }

}
