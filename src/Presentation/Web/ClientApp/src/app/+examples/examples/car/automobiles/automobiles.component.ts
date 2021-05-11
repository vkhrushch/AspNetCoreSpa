import { Component, OnInit } from '@angular/core';
import { AutomobilesClient, AutomobileLookupDto } from '@app/api-client';
import { GridColumn, GridFieldType } from '@app/shared';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { AutomobilesEditComponent } from './edit/edit.component';

@Component({
    selector: 'appc-automobiles',
    templateUrl: './automobiles.component.html',
    styleUrls: ['./automobiles.component.scss'],
})
export class AutomobilesComponent implements OnInit {
    constructor(private automobilesClient: AutomobilesClient, private modalService: NgbModal) { }
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
                    width: 300
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
        const modalRef = this.modalService.open(AutomobilesEditComponent);
        modalRef.componentInstance.automobile = automobile;
        modalRef.result
            .then(() => {
                this.automobilesClient.update(modalRef.componentInstance.automobile.automobileId, modalRef.componentInstance.automobile).subscribe(() => { this.getData });
            })
            .catch();
    }

    deleteAuto(automobile: AutomobileLookupDto) {
        if (window.confirm('Are you sure you want to delete this item?')) {
            this.automobilesClient.delete(automobile.automobileId).subscribe(() => {
                this.getData();
            });
        }
    }
}
