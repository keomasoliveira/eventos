import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AtracoesComponent } from './components/atracoes/atracoes.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PerfilComponent } from './components/perfil/perfil.component';

const routes: Routes = [
  {
    path: 'eventos',
    component: EventosComponent,
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
  },
  {
    path: 'contatos',
    component: ContatosComponent,
  },
  {
    path: 'perfil',
    component: PerfilComponent,
  },
  {
    path: 'atracoes',
    component: AtracoesComponent,
  },
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
  {
    path: '**',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
