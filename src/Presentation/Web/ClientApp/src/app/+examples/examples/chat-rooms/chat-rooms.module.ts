import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here

import { SharedModule } from '@app/shared';
import { routes } from './chat-rooms.routes';


import { ChatRoomsComponent } from './chat-rooms.component';
import { MessagesComponent } from './messages/messages.component';
import { ChatRoomCreateComponent } from './create/create.component';

@NgModule({
    imports: [SharedModule, RouterModule.forChild(routes)],
    declarations: [ChatRoomsComponent, MessagesComponent, ChatRoomCreateComponent]
})
export class ChatRoomsModule { }