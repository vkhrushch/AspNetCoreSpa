import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AutomobilesClient, AutomobileLookupDto } from '@app/api-client';

@Component({
    selector: 'appc-edit',
    templateUrl: './edit.component.html',
    styleUrls: ['./edit.component.scss'],
})
export class AutomobilesEditComponent{

    constructor(private modalService: NgbModal, private activeModal: NgbActiveModal, private automobilesClient: AutomobilesClient) { }
    public automobile: AutomobileLookupDto;

    closeMe() {
        this.modalService.dismissAll();
    };

    sendMe(plateNumber, color, brand, model, year) {
        this.automobile.plateNumber = plateNumber;
        this.automobile.color = color;
        this.automobile.brand = brand;
        this.automobile.model = model;
        this.automobile.year = year;
        this.automobilesClient.update(this.automobile.automobileId, this.automobile).subscribe(() => { });
        this.activeModal.close();
    }
}