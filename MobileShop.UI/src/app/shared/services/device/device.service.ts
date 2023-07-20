import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Device } from 'src/app/models/device.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {

  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllDevices(): Observable<Device[]>{
    return this.http.get<Device[]>(this.baseApiUrl + '/api/Device');
  }

  getDevice(id: string): Observable<Device> {
    return this.http.get<Device>(this.baseApiUrl + '/api/Device/' + id);
  }

  updateDevice(id: string, device: Device): Observable<Device> {
    return this.http.put<Device>(this.baseApiUrl + '/api/Device/' + id, device);
  }

  deleteDevice(id: string): Observable<Device> {
    return this.http.delete<Device>(this.baseApiUrl + '/api/Device/' + id);
  }
}
