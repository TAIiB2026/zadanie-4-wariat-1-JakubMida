import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProduktyComponent } from './produkty/produkty.component';
import { FormularzComponent } from './formularz/formularz.component';
import { RepozytoriumPamiecioweService } from './repozytorium-pamieciowe.service';
import { GET_DATA_TOKEN } from './tokens/get-data.token';
import { FORM_SUBMIT_TOKEN } from './tokens/form-submit.token';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { GetDataService } from './Services/get-data.service';
import { ProductFormService } from './Services/product-form.service';

registerLocaleData(localePl);

@NgModule({
  declarations: [
    AppComponent,
    ProduktyComponent,
    FormularzComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    RepozytoriumPamiecioweService, 
    {
      provide: GET_DATA_TOKEN, useClass: GetDataService,
    }, 
    {
      provide: FORM_SUBMIT_TOKEN, useClass: ProductFormService
    },
    { 
      provide: LOCALE_ID, useValue: 'pl-PL' 
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
