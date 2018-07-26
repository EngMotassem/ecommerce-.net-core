import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { AuthServicesService } from './components/services/auth-services.service';
import { MessageService } from 'primeng/components/common/messageservice';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { GrowlModule } from 'primeng/primeng';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';



@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared,
        BrowserAnimationsModule,
        GrowlModule,
        MessagesModule,
        MessageModule,


    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        AuthServicesService,

        MessageService


    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
