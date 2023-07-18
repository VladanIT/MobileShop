import { ApiServiceService } from './../../../../shared/services/api-service.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Device } from 'src/app/models/device.model';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.css']
})
export class DeviceComponent implements OnInit {

  deviceDetails : Device = {
    id: '',
    brand: '',
    model: '',
    ram: 0,
    rom: 0,
    price: 0
  }

  constructor(private route: ActivatedRoute, private apiService: ApiServiceService, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.apiService.getDevice(id).subscribe({
            next: (response) => {
              this.deviceDetails = response;
            }
          })
        }
      }
    })
  }

}
