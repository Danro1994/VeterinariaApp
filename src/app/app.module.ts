import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MascotasComponent } from './features/mascotas/mascotas.component';
import { InicioComponent } from './features/inicio/inicio.component';
import { CrearMascotaComponent } from './features/crear-mascota/crear-mascota.component';
import { EditarMascotaComponent } from './features/editar-mascota/editar-mascota.component';
import { PaginaNoSeEncuentraComponent } from './features/pagina-no-se-encuentra/pagina-no-se-encuentra.component';
import { NavegacionComponent } from './features/navegacion/navegacion.component';

@NgModule({
  declarations: [
    AppComponent,
    MascotasComponent,
    InicioComponent,
    CrearMascotaComponent,
    EditarMascotaComponent,
    PaginaNoSeEncuentraComponent,
    NavegacionComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
