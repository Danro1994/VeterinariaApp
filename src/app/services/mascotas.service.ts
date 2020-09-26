import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Mascota } from '../models/mascota';

@Injectable({
  providedIn: 'root'
})
export class MascotasService {
  apiURL = 'https://localhost:44349/api/mascota'

  constructor( private http: HttpClient) { }

  obtenerMascotas(){
    return this.http.get<Mascota[]>(this.apiURL);
  }

  obtenerMascota(id: Number){
    return this.http.get<Mascota>(this.apiURL + '/' + id);
  }

  eliminarMascota(id: Number){
    return this.http.delete(this.apiURL + "/" + id);
  }

  crearMascota(mascota: Mascota){
    return this.http.post<Mascota>(this.apiURL, mascota);
  }

  editarMascota(mascota: Mascota){
    return this.http.put<Mascota>(this.apiURL + "/" + mascota.id, mascota);
  }
}

