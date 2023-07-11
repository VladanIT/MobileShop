import { Component, OnInit } from '@angular/core';

import { Device } from './../../../../models/device.model';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {

  devices: Device[] = [
    {
      id: '00000000-0000-0000-0000-000000000000',
      brand: 'Samsung',
      model: 'S7',
      ram: 4,
      rom: 64,
      price: 250
    },
    {
      id: '00000000-0000-0000-0000-000000000001',
      brand: 'Samsung',
      model: 'S10+',
      ram: 6,
      rom: 256,
      price: 360
    },
    {
      id: '00000000-0000-0000-0000-000000000002',
      brand: 'Apple',
      model: 'X',
      ram: 4,
      rom: 64,
      price: 400
    },
    {
      id: '00000000-0000-0000-0000-000000000003',
      brand: 'Huawei',
      model: 'P30 Pro',
      ram: 8,
      rom: 128,
      price: 250
    },
    {
      id: '00000000-0000-0000-0000-000000000001',
      brand: 'Samsung',
      model: 'S10+',
      ram: 6,
      rom: 256,
      price: 360
    },
    {
      id: '00000000-0000-0000-0000-000000000002',
      brand: 'Apple',
      model: 'X',
      ram: 4,
      rom: 64,
      price: 400
    },
    {
      id: '00000000-0000-0000-0000-000000000003',
      brand: 'Huawei',
      model: 'P30 Pro',
      ram: 8,
      rom: 128,
      price: 250
    }
  ];

  constructor() {}

  ngOnInit(): void {
    this.devices;
  }

}
