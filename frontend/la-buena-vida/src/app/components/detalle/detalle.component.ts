import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Platillo } from '../../models/platillo';
import { PlatilloService } from '../../services/platillo.service';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-detalle',
  templateUrl: './detalle.component.html',
  styleUrls: ['./detalle.component.css'],
  providers: [PlatilloService],
})
export class DetalleComponent implements OnInit {
  public id = '';
  public tipo;
  public params: any;
  public platillos: Platillo;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _platilloService: PlatilloService
  ) {}

  ngOnInit(): void {
    this._route.params.subscribe((params: Params) => {
      if (params.id) {
        this.id = params.id;
        if (this.id == 'desayunos') this.tipo = 1;
        if (this.id == 'comidas') this.tipo = 2;
        if (this.id == 'cenas') this.tipo = 3;
        if (this.id == 'postres') this.tipo = 4;
        if (this.id == 'bebidas') this.tipo = 5;
      }
    });

    this._platilloService.getPlatillos().subscribe(
      (response) => {
        this.platillos = response.filter(p => p.tipo === this.tipo);
      },
      (error) => {
        Swal.fire({
          icon: 'error',
          title: 'Mensaje',
          text: 'Error al consultar platillos.',
        });
        this._router.navigate(['/home']);
      }
    );
  }

  regresarMenu() {
    this._router.navigate(['/menu/']);
  }
}
