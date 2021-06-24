import { Component, OnInit, Input, Output } from '@angular/core';
import { ChatRoomsClient, ChatRoomLookupDto, MessageLookupDto, MessagesClient } from '@app/api-client';
import { IUser } from '../../../shared';
import { MessagesComponent } from './messages/messages.component'
import { AuthorizeService } from '../../../shared';
import { map, tap } from 'rxjs/operators';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ChatRoomCreateComponent } from './create/create.component';
import { Observable} from 'rxjs';

@Component({
    selector: 'appc-chat-rooms',
    templateUrl: './chat-rooms.component.html',
    styleUrls: ['./chat-rooms.component.scss']
})
export class ChatRoomsComponent implements OnInit {
    constructor(private chatRoomsClient: ChatRoomsClient, private messagesClient: MessagesClient, private authorizeService: AuthorizeService, private modalService: NgbModal) { }
    chatRooms: ChatRoomLookupDto[];
    selectedRoom?: ChatRoomLookupDto;
    userName: string;
    allUsers: string[];

    ngOnInit() {
        this.getChatRoom();
        this.authorizeService.getUser().pipe(map(u => u && u.name)).subscribe(i => this.userName = i);
        this.getUsers();
    }

    onSelect(room: ChatRoomLookupDto): void {
        this.selectedRoom = room;
    }

    getChatRoom() {
        this.chatRoomsClient.getAll().subscribe(res => {
            this.chatRooms = res.chatRooms;
        });
    }

    getUsers() {
        this.chatRoomsClient.getAllChatRoomUsers().subscribe(i => { this.allUsers = i });        
    }

    createChatRoom(chatRoom: ChatRoomLookupDto) {
        this.allUsers = this.allUsers.filter(e => e !== this.userName);
        const modalRef = this.modalService.open(ChatRoomCreateComponent);
        modalRef.componentInstance.chatRoom = chatRoom;
        modalRef.componentInstance.allUsers = this.allUsers;
        modalRef.result
            .then(() => {
                this.getChatRoom();
            })
            .catch(() => { });
    }

    switchPages() {
        var r = document.getElementById("chat-rooms");
        var m = document.getElementById("messages");

        if (!r.classList.contains("showing") && !m.classList.contains("showing")) {
            m.classList.add("showing");
            r.classList.add("showing");
        }
        else
        {
            if (r.classList.contains("showing")) {
                r.classList.remove("showing");
                m.classList.remove("showing");
            }
            else {
                r.classList.add("showing");
                m.classList.add("showing");               
            }
        }
    }
}