import { Component, OnInit } from '@angular/core';
import { ChatRoomsClient, ChatRoomLookupDto, MessageLookupDto, MessagesClient } from '@app/api-client';
import { IUser } from '../../../shared';
import { MessagesComponent } from './messages/messages.component'
import { AuthorizeService } from '../../../shared';
@Component({
    selector: 'appc-chat-rooms',
    templateUrl: './chat-rooms.component.html',
    styleUrls: ['./chat-rooms.component.css']
})
export class ChatRoomsComponent implements OnInit {
    constructor(private chatRoomsClient: ChatRoomsClient, private messagesClient: MessagesClient) { }
    chatRooms: ChatRoomLookupDto[];
    selectedRoom?: ChatRoomLookupDto;
    auth: AuthorizeService;
    _user?: IUser;

    ngOnInit() {
        this.getChatRoom();
    }

    onSelect(room: ChatRoomLookupDto): void {
        this.selectedRoom = room;
    }

    getChatRoom() {
        this.chatRoomsClient.getAll().subscribe(res => {
            this.chatRooms = res.chatRooms;
        });
    }
   
}