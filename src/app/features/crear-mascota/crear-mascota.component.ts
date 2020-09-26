import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MascotasService } from 'src/app/services/mascotas.service';
import { Mascota } from 'src/app/models/mascota';
import { Raza } from 'src/app/models/raza';
import { RazasService } from 'src/app/services/razas.service';

@Component({
  selector: 'app-crear-mascota',
  templateUrl: './crear-mascota.component.html',
  styleUrls: ['./crear-mascota.component.css']
})
export class CrearMascotaComponent implements OnInit {
  razas: Raza[];
  mascota: Mascota;

  constructor(private _razasService: RazasService,
    private _mascotasService: MascotasService,
    private router: Router) {
      this.mascota = new Mascota();
     }

  ngOnInit() {
    this._razasService.obtenerRazas().subscribe(res => {
      this.razas = res;
    })
  }

  crearMascota(){
    if (this.mascota){
      this._mascotasService.crearMascota(this.mascota).subscribe(() => {
        this.router.navigate(['/mascotas']);
      })
    }
  }

  cancelar(){
    this.router.navigate(['/mascotas']);
  }

}
