import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProjectInfoComponent } from './project-info/project-info.component';
import { RequestedAppointmentsComponent, PETDESK_URL } from './requested-apts/requested-apts.component';
import { RescheduledAppointmentsComponent } from './rescheduled-apts/rescheduled-apts.component';
import { ConfirmedAppointmentsComponent } from './confirmed-apts/confirmed-apts.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        ProjectInfoComponent,
        RequestedAppointmentsComponent,
        RescheduledAppointmentsComponent,
        ConfirmedAppointmentsComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            //{ path: '', component: HomeComponent, pathMatch: 'full' },
            //{ path: 'counter', component: CounterComponent },
            //{ path: 'fetch-data', component: FetchDataComponent },
            { path: '', component: ProjectInfoComponent },
            { path: 'requested-apts', component: RequestedAppointmentsComponent },
            { path: 'rescheduled-apts', component: RescheduledAppointmentsComponent },
            { path: 'confirmed-apts', component: ConfirmedAppointmentsComponent }
        ])
    ],
    providers: [{ provide: "PETDESK_URL", useValue: "https://stageapi.petdesk.com/" }],
    bootstrap: [AppComponent]
})
export class AppModule { }
