import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { DadosCadastroComponent } from './dados-cadastro/dados-cadastro.component';
import { UsuariosRoutingModule } from './usuarios-routing.module';
import { AgGridModule } from 'ag-grid-angular';
import { UsuariosService } from './service/usuarios.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [IndexComponent, DadosCadastroComponent],
  imports: [
    CommonModule,
    UsuariosRoutingModule,
    AgGridModule.withComponents([]),
    ReactiveFormsModule
  ],
  providers: [UsuariosService]
})
export class UsuariosModule { }
