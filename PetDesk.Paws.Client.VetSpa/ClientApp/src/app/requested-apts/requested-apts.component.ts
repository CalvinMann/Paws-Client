import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { InjectionToken } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import { Appointment } from '../shared/models/appointment.type';
import * as signalR from '@aspnet/signalr';

export const PETDESK_URL = new InjectionToken<string>('PETDESK_URL');

@Component({
  selector: 'app-requested-apts',
  templateUrl: './requested-apts.component.html',
})


export class RequestedAppointmentsComponent implements OnInit{
  private appointments = new Map<number, Appointment>();
  private _hubConnection: HubConnection | undefined;
  private _baseUrl: string | undefined;

  constructor(http: HttpClient, @Inject('PETDESK_URL') petDeskURL: string,
    @Inject('BASE_URL') baseUrl: string) {

    this._baseUrl = baseUrl;

  }

  ngOnInit() : void {

    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this._baseUrl + '/appointmentHub')
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this._hubConnection.on('AppointmentRequestedEvent', (appointment: Appointment) => {
      this.appointments.set(appointment.appointmentId,appointment);
    });

    this._hubConnection.on('AppointmentConfirmedEvent', (appointment: Appointment) => {
      this.appointments.delete(appointment.appointmentId);
    });

    this._hubConnection.on('AppointmentRescheduledEvent', (appointment: Appointment) => {
      this.appointments.delete(appointment.appointmentId);
    });

    this._hubConnection.start().catch(err => console.error(err.toString()));

  }

  public appointmentConfirmed(appointment: Appointment) {
    if (this._hubConnection) {
      this._hubConnection.invoke('AppointmentConfirmedCommand', appointment);
    }
  }



  getValues(): Array<Appointment> {
    return Array.from(this.appointments.values());
  }

  public appointmentRescheduled(appointment: Appointment) {
    if (this._hubConnection) {
      this._hubConnection.invoke('AppointmentRescheduledCommand', appointment); 
    }
  }
}






