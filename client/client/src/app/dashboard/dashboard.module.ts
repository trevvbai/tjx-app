import { NgModule } from '@angular/core';
import {MessageService} from "primeng/api";
import {ButtonModule} from "primeng/button";
import {ToastModule} from "primeng/toast";
import {DashboardComponent} from "./dashboard.component";
import {CommonModule} from "@angular/common";
import {TableModule} from "primeng/table";
import {Accordion, AccordionModule} from "primeng/accordion";
import {CardModule} from "primeng/card";

@NgModule({
	declarations: [
		// Declare components here. The first component is usually the root component.
		DashboardComponent
	],
	imports: [
		CommonModule,
		ButtonModule,
		ToastModule,
		TableModule,
		AccordionModule,
		CardModule
	],
	providers: [
		// Register application-wide services here.
		MessageService,
		Accordion
	]
})
export class DashboardModule { }
