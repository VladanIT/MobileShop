import { Component, OnInit } from '@angular/core';
import { Device } from 'src/app/models/device.model';
import { ApiServiceService } from 'src/app/shared/services/api-service.service';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {

  devices: Device[] = [];

  constructor(private apiService: ApiServiceService) {}

  ngOnInit(): void {
    this.apiService.getAllDevices().subscribe({
      next: (device) => {
        this.devices = device;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }

}
