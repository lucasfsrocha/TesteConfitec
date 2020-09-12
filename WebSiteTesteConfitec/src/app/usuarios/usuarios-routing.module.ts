import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { DadosCadastroComponent } from './dados-cadastro/dados-cadastro.component';

const routes: Routes = [
  {path: '', component: IndexComponent},
  {path: 'dados-cadastro/adicionar', component: DadosCadastroComponent},
  {path: 'dados-cadastro/editar', component: DadosCadastroComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuariosRoutingModule { }
