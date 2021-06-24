import { Component, OnInit , Input} from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ChatRoomsClient, ChatRoomLookupDto } from '@app/api-client';
import { map, tap } from 'rxjs/operators';
import { AuthorizeService } from '../../../../shared';

@Component({
  selector: 'appc-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class ChatRoomCreateComponent {

    constructor(private modalService: NgbModal, private activeModal: NgbActiveModal, private chatRoomsClient: ChatRoomsClient, private authorizeService: AuthorizeService ) {}
    public chatRoom: ChatRoomLookupDto;
    userName: string;
    participants: string[] = [];
    allUsers: string[];
    selectedParticipant: string;

    closeWindow() {
        this.modalService.dismissAll();
    };

    selectChangeHandler(event: any) {
        //update the ui
        this.selectedParticipant = event.target.value;
    }
    
    createChatRoom(name, participant)
    {
        this.authorizeService.getUser().pipe(map(u => u && u.name)).subscribe(i => this.userName = i);
        this.participants.push(this.userName, this.selectedParticipant);
        /*this.participants.push(this.userName);*/
        this.chatRoom = new ChatRoomLookupDto();
        this.chatRoom.name = name;
        this.chatRoomsClient.create(this.chatRoom.name, this.participants).subscribe(() => { });
        this.activeModal.close();
        this.chatRoomsClient.getAll().subscribe(() => { });
    }

}
