import { Component, OnInit } from '@angular/core';
import { ClientsClient, ClientLookupDto } from '@app/api-client';
import { GridColumn } from '@app/shared';

@Component({
    selector: 'appc-clients',
    templateUrl: './clients.component.html',
    styleUrls: ['./clients.component.scss'],
})
export class ClientsComponent implements OnInit {
    constructor(private clientClient: ClientsClient) { }
    clients: ClientLookupDto[];
    columns: GridColumn[];
    ngOnInit() {
        this.clientClient.getAll().subscribe(res => {
            this.clients = res.clients;
            this.columns = [
                {
                    field: 'firstName',
                    filter: true,
                    sortable: true,
                },
                {
                    field: 'lastName',
                    filter: true,
                    sortable: true,
                },
            ];
        });
    }
}
