import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { DevicesComponent } from './components/devices/devices.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DeviceComponent } from './components/device/device.component';
import { FormsModule } from '@angular/forms';
import { UsersComponent } from './components/users/users.component';
import { UserComponent } from './components/user/user.component';


@NgModule({
  declarations: [
    DevicesComponent,
    DeviceComponent,
    UsersComponent,
    UserComponent
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
