import {Component, OnInit} from '@angular/core';
import {DashboardService} from "../services/dashboard/dashboard.service";
import {Product} from "../models/product";
import {MessageService} from "primeng/api";
import {messageTypes} from "../enums/messageTypes";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent implements OnInit{
	products: Product[] = [];

	constructor(
		private dashboardService: DashboardService,
		private messageService: MessageService,
	) {
	}

	ngOnInit() {
		this.getProducts();
	}

	getProducts():void{
		this.dashboardService.getDashboardProducts().subscribe({
			next: (res) => {
				if (res.body) {
					this.products = res.body;
				}
			},
			error: (e) => {
				this.showError(e);
			}
		})
	}

	private showError(e: any) {
		this.messageService.add({severity: messageTypes.Error, summary: 'Error', detail: 'Error Loading Product Data'})

	}
}
