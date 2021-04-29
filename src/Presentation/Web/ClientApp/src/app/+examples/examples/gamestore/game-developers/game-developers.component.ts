import { Component, OnInit } from '@angular/core';

import { GameDevelopersClient, GameDeveloperDto } from '@app/api-client';
import { GridColumn, GridFieldType } from '@app/shared';
import { LargeTextCellEditor } from 'ag-grid-community';

@Component({
    selector: 'appc-game-developers',
    templateUrl: './game-developers.component.html',
    styleUrls: ['./game-developers.component.scss'],
})
export class GameDevelopersComponent implements OnInit {
    constructor(private gameDevelopersClient: GameDevelopersClient) { }
    gameDevelopers: GameDeveloperDto[];
    columns: GridColumn[] = [
        {
            field: 'firstName',
            filter: true,
            sortable: true,
            width: 100,
        },
        {
            field: 'lastName',
            filter: true,
            sortable: true,
            width: 100,
        },
        {
            field: 'age',
            type: GridFieldType.Number,
            filter: true,
            sortable: true,
            width: 50,
        },
        {
            field: 'developerLevel',
            filter: true,
            sortable: true,
            width: 100,
        },
        {
            type: GridFieldType.ActionButtons,
            cellRendererParams: {
                primaryClicked: this.editGameDeveloper.bind(this),
                secondaryClicked: this.deleteGameDeveloper.bind(this),
                primaryLabel: 'Edit Game Developer',
                secondaryLabel: 'Delete Game Developer',
            },
        },
    ];
    ngOnInit() {
        this.getData();
    }

    getData() {
        this.gameDevelopersClient.getAll().subscribe(res => {
            this.gameDevelopers = res.gameDevelopers;
        });
    }
    editGameDeveloper(gameDeveloper: GameDeveloperDto) {
        console.log(gameDeveloper);
        // this.productsClient.delete(product.productId).subscribe(this.getData);
    }

    deleteGameDeveloper(gameDeveloper: GameDeveloperDto) {
        this.gameDevelopersClient.delete(gameDeveloper.id).subscribe(this.getData); // game.productId => game.id?
    }
}