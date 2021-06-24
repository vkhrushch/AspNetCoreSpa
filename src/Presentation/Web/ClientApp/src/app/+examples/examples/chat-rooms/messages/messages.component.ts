import { Component, OnInit, Input, SimpleChanges, OnChanges, Output, Inject, ViewChild, ElementRef  } from '@angular/core';
import { ChatRoomsClient, ChatRoomLookupDto, MessageLookupDto, MessagesClient } from '@app/api-client';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { AuthorizeService } from '../../../../shared';

@Component({
    selector: 'appc-messages',
    templateUrl: './messages.component.html',
    styleUrls: ['./messages.component.scss']
})

export class MessagesComponent implements OnChanges {

    constructor(private chatRoomsClient: ChatRoomsClient, private messagesClient: MessagesClient, private authorizeService: AuthorizeService, @Inject('BASE_URL') private baseUrl: string) { }

    @ViewChild('target') private messagesContainer: ElementRef;
    @Input() room?: ChatRoomLookupDto;
    private hub: HubConnection;
    messages: MessageLookupDto[];
    text: string = "";
    userName: string;
    messageId: number;
    allUsers: string[];

    ngOnInit() {
        this.authorizeService.getUser().pipe(map(u => u && u.name)).subscribe(i => this.userName = i);
        this.hub = new HubConnectionBuilder().withUrl(`${this.baseUrl}chathub`).build();
        this.getUsers();
        this.hub.on('sendMessage', (data: any) => {
            const received = data;
            this.messages.push(received);
        });

        this.baseUrl;
        
        this.hub
            .start()
            .then(() => console.log('Hub connection started'))
            .catch(err => console.log('Error while establishing connection: ' + err));
        
        if (this.room != null) {
            this.getMessagesByRoomId(this.room);
        }
    }

    ngOnChanges() {
        if (this.room != null) {
            this.getMessagesByRoomId(this.room);
        }
    }

    scrollToElement(): void {
        this.messagesContainer.nativeElement.scroll({
            top: this.messagesContainer.nativeElement.scrollHeight,
            left: 0,
            behavior: 'smooth'
        });
    }

    getMessagesByRoomId(room: ChatRoomLookupDto) {
        this.messagesClient.getAllByRoom(room.roomId).subscribe(res => {
            this.messages = res.messages;
            setTimeout(function () { }, 0);
            this.scrollToElement();
        });
    }

    getUsers() {
        this.chatRoomsClient.getAllChatRoomUsers().subscribe(i => { this.allUsers = i });
    }


    addMessage(textMessage: HTMLInputElement, roomId: number) {
        if (textMessage.value != "") {
           this.messagesClient.create(roomId, textMessage.value, this.userName).subscribe(res => {
               this.hub.invoke('sendMessage', res);
                textMessage.value = "";
               this.ngOnChanges();
            });
        }
    }
}

