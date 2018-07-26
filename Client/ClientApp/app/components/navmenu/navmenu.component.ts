import { Component, OnInit } from '@angular/core';

import { AuthServicesService } from '../services/auth-services.service';

import { Message } from 'primeng/components/common/api';





import { MessageService } from 'primeng/components/common/messageservice';

import { GrowlModule } from 'primeng/growl';
import { CommonModule } from '@angular/common';



@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css'],
    providers: [MessageService]
})


export class NavMenuComponent implements OnInit {

    model: any = {};
    msgs: Message[] = [];

    constructor(private authService: AuthServicesService,
        private messageService: MessageService) { }

    ngOnInit() {
    }

    login() {
        this.authService.login(this.model).subscribe(data => {
            console.log('logged in successfully');
           // this.addSingle();
        }, error => {
            console.log('failed to login');

            this.showError();

            //this.message = "check user name and password";
        });
    }

    logout() {
        this.authService.userToken = null;
        localStorage.removeItem('token');
        console.log('logged out');
    }

    loggedIn() {
        const token = localStorage.getItem('token');
        return !!token;
    }


    showSuccess() {
        this.msgs = [];
        this.msgs.push({ severity: 'success', summary: 'Success Message', detail: 'Order submitted' });
    }

    showInfo() {
        this.msgs = [];
        this.msgs.push({ severity: 'info', summary: 'Info Message', detail: 'PrimeNG rocks' });
    }

    showWarn() {
        this.msgs = [];
        this.msgs.push({ severity: 'warn', summary: 'Warn Message', detail: 'There are unsaved changes' });
    }

    showError() {
        this.msgs = [];
        this.msgs.push({ severity: 'error', summary: 'Error Message', detail: 'Validation failed' });
    }

    showMultiple() {
        this.msgs = [];
        this.msgs.push({ severity: 'info', summary: 'Message 1', detail: 'PrimeNG rocks' });
        this.msgs.push({ severity: 'info', summary: 'Message 2', detail: 'PrimeUI rocks' });
        this.msgs.push({ severity: 'info', summary: 'Message 3', detail: 'PrimeFaces rocks' });
    }

    showViaService() {
        this.messageService.add({ severity: 'success', summary: 'Service Message', detail: 'Via MessageService' });
    }

    clear() {
        this.msgs = [];
    }
    

}


