"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.routes = void 0;
var car_component_1 = require("./car.component");
var clients_component_1 = require("./clients/clients.component");
var car_experts_component_1 = require("./car-experts/car-experts.component");
var automobiles_component_1 = require("./automobiles/automobiles.component");
exports.routes = [
    {
        path: '',
        component: car_component_1.CarComponent,
        data: { displayText: 'Car' },
        children: [
            { path: '', redirectTo: 'clients' },
            { path: 'clients', component: clients_component_1.ClientsComponent, data: { state: 'clients', displayText: 'Clients' } },
            { path: 'car-experts', component: car_experts_component_1.CarExpertsComponent, data: { state: 'car-experts', displayText: 'Car Experts' } },
            { path: 'automobiles', component: automobiles_component_1.AutomobilesComponent, data: { state: 'automobiles', displayText: 'Automobiles' } },
        ],
    },
];
//# sourceMappingURL=car.routes.js.map