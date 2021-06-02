import { Component, OnInit, Input, SimpleChanges, OnChanges, Output } from '@angular/core';
import { ChatRoomLookupDto, MessageLookupDto, MessagesClient } from '@app/api-client';

@Component({
    selector: 'appc-messages',
    templateUrl: './messages.component.html',
    styleUrls: ['./messages.component.css']
})

export class MessagesComponent implements OnChanges {

    constructor(private messagesClient: MessagesClient) { }

    @Input() room?: ChatRoomLookupDto;
    messages: MessageLookupDto[];
    text: string = "";
    ngOnInit() {
        if (this.room != null) {
            this.getMessagesByRoomId(this.room);
        }

    }
    ngOnChanges() {
        if (this.room != null) {
            this.getMessagesByRoomId(this.room);            
        }
    }

    getMessages() {
        this.messagesClient.getAll().subscribe(res => {
            this.messages = res.messages;            
        });

    }
    getMessagesByRoomId(room: ChatRoomLookupDto) {
        this.messagesClient.getAllByRoom(room.roomId).subscribe(res => {
            this.messages = res.messages;
        });
    }
    addMessage(textMessage: HTMLInputElement, roomId: number) {
        if (textMessage.value != "") {
            this.messagesClient.create(roomId, textMessage.value).subscribe(res => {
                textMessage.value = "";
                this.ngOnChanges();
            });
        }
        
    }

}

