import {Component, OnInit} from '@angular/core';
import {DashboardService} from "../services/dashboard/dashboard.service";
import {Product} from "../models/product";
import {MessageService} from "primeng/api";
import {messageTypes} from "../enums/messageTypes";
import {Country} from "../models/country";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
})
export class DashboardComponent implements OnInit{
	products: Product[] = [];
	allCountries : Country[] = [];
	selectedCountry: Country;

	constructor(
		private dashboardService: DashboardService,
		private messageService: MessageService,
	) {
	}

	ngOnInit() {
		this.getProducts();
		this.getCountries();
	}

	getProducts():void{
		this.dashboardService.getDashboardProducts().subscribe({
			next: (res) => {
				if (res.body) {
					this.products = res.body;
				}
			},
			error: (e: Error) => {
				this.showError(e.message);
			}
		})
	}

	private getCountries() {
		this.dashboardService.getDashboardCountries().subscribe({
			next: (res) => {
				if (res.body) {
					this.allCountries = res.body;
					this.selectedCountry = this.allCountries[0]
				}
			},
			error: (e: Error) => {
				this.showError(e.message);
			}
		})
	}

	private showError(e: any) {
		this.messageService.add({severity: messageTypes.Error, summary: 'Error', detail: 'Error Loading Product Data'})
	}

	handleDropdownChange($event: Country) {
		this.selectedCountry = $event;
	}
}
