import { Component, OnInit } from '@angular/core';
import { CarExpertClient, CarExpertLookupDto } from '@app/api-client';
import { GridColumn } from '@app/shared';

@Component({
    selector: 'appc-car-experts',
    templateUrl: './car-experts.component.html',
    styleUrls: ['./car-experts.component.scss'],
})
export class CarExpertsComponent implements OnInit {
    constructor(private carExpertClient: CarExpertClient) { }
    carExperts: CarExpertLookupDto[];
    columns: GridColumn[];
    ngOnInit() {
        this.carExpertClient.getAll().subscribe(res => {
            this.carExperts = res.carExperts;
            this.columns = [
                {
                    field: 'name',
                    filter: true,
                    sortable: true,
                },
                {
                    field: 'level',
                    filter: true,
                    sortable: true,
                },
            ];
        });
    }
}
