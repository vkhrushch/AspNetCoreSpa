import { Component, OnInit } from '@angular/core';
import { AutomobilesClient, AutomobileLookupDto, UpdateAutomobileCommand } from '@app/api-client';
import { GridColumn, GridFieldType } from '@app/shared';

@Component({
    selector: 'appc-automobiles',
    templateUrl: './automobiles.component.html',
    styleUrls: ['./automobiles.component.scss'],
})
export class AutomobilesComponent implements OnInit {
    constructor(private automobilesClient: AutomobilesClient) { }
    automobiles: AutomobileLookupDto[];
    columns: GridColumn[];
    ngOnInit() {
        this.automobilesClient.getAll().subscribe(res => {
            this.automobiles = res.automobiles;
            this.columns = [
                {
                    field: 'clientId',
                    filter: true,
                    sortable: true,
                },
                {
                    field: 'carExpertId',
                    filter: true,
                    sortable: true,
                },
                {
                    field: 'plateNumber',
                    filter: true,
                    sortable: true,
                },
                {
                    field: 'color',
                    filter: true,
                    sortable: true,
                },
                {
                    field: 'brand',
                    filter: true,
                    sortable: true,
                },
                {
                    field: 'model',
                    filter: true,
                    sortable: true,
                },
                {
                    field: 'year',
                    filter: true,
                    sortable: true,
                },
                {
                    type: GridFieldType.ActionButtons,
                    cellRendererParams: {
                        primaryClicked: this.editAuto.bind(this),
                        secondaryClicked: this.deleteAuto.bind(this),
                        primaryLabel: 'Edit Automobile',
                        secondaryLabel: 'Delete Automobile',
                    },
                },
            ];            
        });
    }
    getData() {
        this.automobilesClient.getAll().subscribe(res => {
            this.automobiles = res.automobiles;
        });
    }
    editAuto(automobile: AutomobileLookupDto) {
        console.log(automobile);

        this.automobilesClient.update(automobile.automobileId.toString(), UpdateAutomobileCommand.fromJS(automobile));
        // this.productsClient.delete(product.productId).subscribe(this.getData);
    }

    deleteAuto(automobile: AutomobileLookupDto) {
        this.automobilesClient.delete(automobile.automobileId).subscribe(this.getData);
    }
}
