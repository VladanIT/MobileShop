import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DevicesComponent } from './components/devices/devices.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DeviceComponent } from './components/device/device.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    DevicesComponent,
    DeviceComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule,
    TableModule,
    ButtonModule,
    FormsModule
  ]
})
export class AdminModule { }
