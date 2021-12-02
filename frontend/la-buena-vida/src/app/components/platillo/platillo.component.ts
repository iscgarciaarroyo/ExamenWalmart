import { Component, Input, OnInit } from '@angular/core';
import { Platillo } from 'src/app/models/platillo';

@Component({
  selector: 'app-platillo',
  templateUrl: './platillo.component.html',
  styleUrls: ['./platillo.component.css']
})
export class PlatilloComponent implements OnInit {
  @Input() platillos: Platillo[];
  constructor() { }

  ngOnInit(): void {
  }

  agregarPlatilloCarrito(platillo){
    console.log(platillo.precio);
    const total = document.getElementById('totalSeleccionado');
    console.log(parseFloat(total.innerHTML));
    if(!isNaN(parseFloat(total.innerHTML))){
      const nuevoTotal = parseFloat(total.innerHTML) + parseFloat(platillo.precio);
      const txt = document.createTextNode(nuevoTotal.toString() + ".00");
      total.innerHTML = '';
      total.appendChild(txt);
    }

  }

}
