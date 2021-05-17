import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AutomobilesClient, AutomobileLookupDto } from '@app/api-client';

@Component({
    selector: 'appc-edit',
    templateUrl: './create.component.html',
})
export class AutomobilesCreateComponent {

    constructor(private modalService: NgbModal, private activeModal: NgbActiveModal, private automobilesClient: AutomobilesClient) { }
    public automobile: AutomobileLookupDto;

    closeWindow() {
        this.modalService.dismissAll();
    };

    createAuto(plateNumber, model, color, brand, year, clientId, carExpertId) {
        this.automobile = new AutomobileLookupDto();
        this.automobile.plateNumber = plateNumber;
        this.automobile.model = model;
        this.automobile.color = color;
        this.automobile.brand = brand;
        this.automobile.year = year;
        this.automobile.clientId = clientId;
        this.automobile.carExpertId = carExpertId;
        this.automobilesClient.create(this.automobile).subscribe(() => { });
        this.activeModal.close();
    }
}