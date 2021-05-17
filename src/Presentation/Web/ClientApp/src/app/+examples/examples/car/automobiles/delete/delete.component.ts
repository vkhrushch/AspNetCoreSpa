import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AutomobilesClient, AutomobileLookupDto } from '@app/api-client';

@Component({
    selector: 'appc-edit',
    templateUrl: './delete.component.html',
})
export class AutomobilesDeleteComponent {

    constructor(private modalService: NgbModal, private activeModal: NgbActiveModal, private automobilesClient: AutomobilesClient) { }
    public automobile: AutomobileLookupDto;

    closeMe() {
        this.modalService.dismissAll();
    };

    sendMe() {
       
        this.automobilesClient.delete(this.automobile.automobileId).subscribe(() => { });
        this.activeModal.close();
    }
}