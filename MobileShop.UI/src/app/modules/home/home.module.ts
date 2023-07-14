import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from 'src/app/shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './components/home/home.component';
import { DevicesComponent } from './components/devices/devices.component';
import { ButtonModule } from 'primeng/button';
import { DataViewModule, DataViewLayoutOptions } from 'primeng/dataview';


@NgModule({
  declarations: [
    HomeComponent,
    DevicesComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule,
    ButtonModule,
    DataViewModule
  ]
})
export class HomeModule { }
