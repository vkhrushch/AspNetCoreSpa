import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AutomobileLookupDto } from '@app/api-client';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
    selector: 'appc-edit',
    templateUrl: './edit.component.html',
    styleUrls: ['./edit.component.scss'],
})
export class AutomobilesEditComponent implements OnInit {
    constructor(private modalService: NgbModal, private activeModal: NgbActiveModal) { }
    public automobile: AutomobileLookupDto;
    public autoPlateNumber;
    //@Output() passEntry: EventEmitter<any> = new EventEmitter();
    closeMe() {
        this.modalService.dismissAll();
    };
    sendMe() {
        this.activeModal.close();
        //this.passEntry.emit(this.game);
    }
    ngOnInit() {
        this.autoPlateNumber = this.automobile.plateNumber;
    }
}