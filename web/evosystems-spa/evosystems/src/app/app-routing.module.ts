import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartamentoFormComponent } from './components/departamento/departamento-form/departamento-form.component';
import { DepartamentoGridComponent } from './components/departamento/departamento-grid/departamento-grid.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'departamento-grid', // Redireciona para o departamento-grid por padrão
    pathMatch: 'full',
  },
  {
    path: 'departamento-form',
    component: DepartamentoFormComponent,
  },
  {
    path: 'departamento-grid',
    component: DepartamentoGridComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
