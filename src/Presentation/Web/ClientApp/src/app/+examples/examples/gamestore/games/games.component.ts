import { Component, OnInit } from '@angular/core';

import { GamesClient, GameDto } from '@app/api-client';
import { GridColumn, GridFieldType } from '@app/shared';
import { LargeTextCellEditor } from 'ag-grid-community';

@Component({
    selector: 'appc-games',
    templateUrl: './games.component.html',
    styleUrls: ['./games.component.scss'],
})
export class GamesComponent implements OnInit {
    constructor(private gamesClient: GamesClient) { }
    games: GameDto[];
    columns: GridColumn[] = [
        {
            field: 'name',
            filter: true,
            sortable: true,
            width: 100,
        },
        {
            field: 'difficulty',
            filter: true,
            sortable: true,
            width: 180,
        },
        {
            type: GridFieldType.ActionButtons,
            cellRendererParams: {
                primaryClicked: this.editGame.bind(this),
                secondaryClicked: this.deleteGame.bind(this),
                primaryLabel: 'Edit Game',
                secondaryLabel: 'Delete Game',
            },
        },
    ];
    ngOnInit() {
        this.getData();
    }

    getData() {
        this.gamesClient.getAll().subscribe(res => {
            this.games = res.games;
        });
    }
    editGame(game: GameDto) {
        console.log(game);
        // this.productsClient.delete(product.productId).subscribe(this.getData);
    }

    deleteGame(game: GameDto) {
        this.gamesClient.delete(game.id).subscribe(this.getData); // game.productId => game.id?
    }
}