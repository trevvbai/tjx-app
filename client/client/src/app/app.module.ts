import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {AppRoutingModule} from "./app-routing.module";
import {DashboardService} from "./services/dashboard/dashboard.service";
import {CommonModule} from "@angular/common";
import {RouterModule} from "@angular/router";
import {MessageService} from "primeng/api";
import {DashboardModule} from "./dashboard/dashboard.module";
import {ToastModule} from "primeng/toast";

@NgModule({
	declarations: [
		AppComponent,
	],
	imports: [
		BrowserModule,
		CommonModule,
		RouterModule,
		AppRoutingModule,
		HttpClientModule,
		FormsModule,
		BrowserAnimationsModule,
		DashboardModule,
		ToastModule,
	],
	providers: [
		DashboardService,
		MessageService,
	],
	bootstrap: [
		AppComponent
	]
})
export class AppModule { }
