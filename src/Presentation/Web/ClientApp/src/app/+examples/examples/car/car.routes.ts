import { CarComponent } from "./car.component";
import { ClientsComponent } from "./clients/clients.component";
import { CarExpertsComponent } from "./car-experts/car-experts.component";
import { AutomobilesComponent } from "./automobiles/automobiles.component";

export const routes = [
    {
        path: '',
        component: CarComponent,
        data: { displayText: 'Car' },
        children: [
            { path: '', redirectTo: 'clients' },
            { path: 'clients', component: ClientsComponent, data: { state: 'clients', displayText: 'Clients' } },
            { path: 'car-experts', component: CarExpertsComponent, data: { state: 'car-experts', displayText: 'Car Experts' } },
            { path: 'automobiles', component: AutomobilesComponent, data: { state: 'automobiles', displayText: 'Automobiles' } },
        ],
    },
];