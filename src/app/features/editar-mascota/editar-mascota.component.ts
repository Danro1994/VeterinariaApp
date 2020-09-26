import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MascotasService } from 'src/app/services/mascotas.service';
import { Mascota } from 'src/app/models/mascota';
import { Raza } from 'src/app/models/raza';
import { RazasService } from 'src/app/services/razas.service';

@Component({
  selector: 'app-editar-mascota',
  templateUrl: './editar-mascota.component.html',
  styleUrls: ['./editar-mascota.component.css']
})
export class EditarMascotaComponent implements OnInit {
  razas: Raza[];
  mascota: Mascota;

  constructor(private _razasService: RazasService,
    private _mascotasService: MascotasService,
    private router: Router,
    private route: ActivatedRoute) {
      this.mascota = new Mascota();
     }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id');

    this._razasService.obtenerRazas().subscribe(res => {
      this.razas = res;
    });

    this._mascotasService.obtenerMascota(id).subscribe(res => {
      this.mascota = res;
    });
  }

  editarMascota(){
    this._mascotasService.editarMascota(this.mascota)
    .subscribe(() => {
      this.router.navigate(['/mascotas']);
    })
  }

  cancelar(){
    this.router.navigate(['mascotas']);
  }

}
