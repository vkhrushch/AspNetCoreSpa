import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '@app/shared';

import { routes } from './car.routes';
import { CarComponent } from './car.component';
import { ClientsComponent } from './clients/clients.component';
import { CarExpertsComponent } from "./car-experts/car-experts.component";
import { AutomobilesComponent } from "./automobiles/automobiles.component";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AutomobilesEditComponent } from './automobiles/edit/edit.component';

@NgModule({
    imports: [SharedModule, FormsModule, ReactiveFormsModule, RouterModule.forChild(routes)],
    declarations: [CarComponent, ClientsComponent, CarExpertsComponent, AutomobilesComponent],
})
export class CarModule { }