import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MascotasService } from 'src/app/services/mascotas.service';
import { Mascota } from 'src/app/models/mascota';


@Component({
  selector: 'app-mascotas',
  templateUrl: './mascotas.component.html',
  styleUrls: ['./mascotas.component.css']
})
export class MascotasComponent implements OnInit {
  mascotas: Mascota[];

  constructor( private _mascotasService: MascotasService, private router: Router) { }

  ngOnInit(){
    this.obtenerMascotas();
  }

  crearMascota(){
    this.router.navigate(['/mascotas/crear']);
  }

  editarMascota(id: Number){
    this.router.navigate(['/mascotas/editar', id]);
  }

  obtenerMascotas(){
    this._mascotasService.obtenerMascotas().subscribe(data => {
      this.mascotas = data;
    });
  }

  eliminarMascota(id: Number){
    const res = confirm("Desea eliminar esta mascota?");
    if(res){
      this._mascotasService.eliminarMascota(id).subscribe(() => {
        this.obtenerMascotas();
      })
    }
  }

}
