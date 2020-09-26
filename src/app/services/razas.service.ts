import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Raza } from '../models/raza';

@Injectable({
  providedIn: 'root'
})
export class RazasService {
  apiUrl = 'https://localhost:44349/api/raza';

  constructor(private http: HttpClient) { }

  obtenerRazas(){
    return this.http.get<Raza[]>(this.apiUrl);
  }
}
