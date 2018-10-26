import { Injectable, Inject } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { Appointment } from '../models/appointment.type';
import { log } from 'util';


@Injectable()
export class AppointmentHubService {

  //TODO: Instead of invoking all the new connections,
  //could I just add the call backs?

  private _hubConnection: HubConnection | undefined;
  private _baseUrl: string | undefined;

  constructor(@Inject('BASE_URL') baseUrl : string) {
    this._baseUrl = baseUrl;
    this.init();
  }

  appointmentConfirmed(appointment: Appointment): Appointment {
    if (this._hubConnection) {
      this._hubConnection.invoke('AppointmentConfirmed', appointment);
    }
    return appointment;
  }

  private init() {

    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this._baseUrl +'/appointmentHub')
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this._hubConnection.on('AppointmentConfirmed', (appointment: Appointment) => {

    });

    this._hubConnection.start().catch(err => console.error(err.toString()));

  }


}
