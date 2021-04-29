import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { SharedModule } from '@app/shared';

import { routes } from './gamestore.routes';
import { GameStoreComponent } from './gamestore.component';
import { GamesComponent } from './games/games.component';
import { GameDevelopersComponent } from './game-developers/game-developers.component';

@NgModule({
    imports: [SharedModule, RouterModule.forChild(routes)],
    declarations: [GameStoreComponent, GamesComponent, GameDevelopersComponent],
})
export class GameStoreModule { }