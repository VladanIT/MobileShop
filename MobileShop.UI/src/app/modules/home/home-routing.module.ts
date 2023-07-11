import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { DevicesComponent } from './components/devices/devices.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'devices',
    component: DevicesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
