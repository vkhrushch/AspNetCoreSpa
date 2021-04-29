import { GameStoreComponent } from './gamestore.component';
import { GamesComponent } from './games/games.component';
import { GameDevelopersComponent } from './game-developers/game-developers.component';

export const routes = [
    {
        path: '',
        component: GameStoreComponent,
        data: { displayText: 'GameStore' },
        children: [
            { path: '', redirectTo: 'games' },
            { path: 'games', component: GamesComponent, data: { state: 'games', displayText: 'Games' } },
            { path: 'game-developers', component: GameDevelopersComponent, data: { state: 'game-developers', displayText: 'Game Developers' } }
        ],
    },
];