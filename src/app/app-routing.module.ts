import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InicioComponent } from './features/inicio/inicio.component';
import { MascotasComponent } from './features/mascotas/mascotas.component';
import { CrearMascotaComponent } from './features/crear-mascota/crear-mascota.component';
import { EditarMascotaComponent } from './features/editar-mascota/editar-mascota.component';
import { PaginaNoSeEncuentraComponent } from './features/pagina-no-se-encuentra/pagina-no-se-encuentra.component';

const routes: Routes = [
  { path: '', component: InicioComponent},
  { path: 'mascotas', component: MascotasComponent},
  { path: 'mascotas/crear', component: CrearMascotaComponent},
  { path: 'mascotas/editar/:id', component: EditarMascotaComponent},
  { path: '**', component: PaginaNoSeEncuentraComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
