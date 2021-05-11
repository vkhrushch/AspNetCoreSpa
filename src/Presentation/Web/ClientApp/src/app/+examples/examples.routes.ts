import { Routes } from '@angular/router';

import { ExamplesComponent } from './examples.component';
import { FormsPlaygroundComponent } from './examples/forms-playground/forms-playground.component';

export const routes: Routes = [
    { path: '', component: ExamplesComponent, data: { displayText: 'Home' } },
    { path: 'forms-playground', component: FormsPlaygroundComponent, data: { displayText: 'Forms playground' } },
    {
        path: 'signalr',
        loadChildren: () => import('./examples/signalr/signalr.module').then(m => m.SignalrModule),
        data: { displayText: 'SignalR' },
    },
    {
        path: 'shop',
        loadChildren: () => import('./examples/shop/shop.module').then(m => m.ShopModule),
        data: { displayText: 'Shop' },
    },
    {
        path: 'car',
        loadChildren: () => import('./examples/car/car.module').then(m => m.CarModule),
        data: { displayText: 'Car' },
    },
    {
        path: 'gamestore',
        loadChildren: () => import('./examples/gamestore/gamestore.module').then(m => m.GameStoreModule),
        data: { displayText: 'GameStore' },
    }
];
