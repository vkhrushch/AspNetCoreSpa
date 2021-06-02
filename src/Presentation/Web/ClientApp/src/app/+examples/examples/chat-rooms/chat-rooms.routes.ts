import { ChatRoomsComponent } from "./chat-rooms.component";

export const routes = [
    {
        path: '',
        component: ChatRoomsComponent,
        data: { displayText: 'ChatRooms' },
    },
];