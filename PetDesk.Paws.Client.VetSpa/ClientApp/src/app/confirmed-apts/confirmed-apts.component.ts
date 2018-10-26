import { Component, Inject, OnInit } from '@angular/core';
import { Appointment } from '../shared/models/appointment.type';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';

@Component({
    selector: 'app-confirmed-apts',
    templateUrl: './confirmed-apts.component.html',
})
export class ConfirmedAppointmentsComponent implements OnInit {
  private appointments = new Map<number, Appointment>();
  private _hubConnection: HubConnection | undefined;
  private _baseUrl: string | undefined;

  constructor(@Inject('BASE_URL') baseUrl: string) {
 
    this._baseUrl = baseUrl;

  }

  async ngOnInit(): Promise<void> {

    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this._baseUrl + '/appointmentHub')
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this._hubConnection.on('LoadConfirmedAppointmentsEvent', (appointments: Appointment[]) => {
      for (let appointment of appointments) {
        this.appointments.set(appointment.appointmentId, appointment);
      }
    });

    this._hubConnection.on('AppointmentConfirmedEvent', (appointment: Appointment) => {
      //This is where we add a row to the view
      this.appointments.set(appointment.appointmentId, appointment);

    });

    await this._hubConnection.start().catch(err => console.error(err.toString()));

    this.loadAppointments();
  }

  private loadAppointments() {
    if (this._hubConnection) {
      this._hubConnection.invoke('LoadAppointmentsCommand', "Confirmed");
    }
  }

  getValues(): Array<Appointment> {
    return Array.from(this.appointments.values());
  }

}
