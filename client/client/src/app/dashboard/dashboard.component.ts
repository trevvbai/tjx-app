import {Component, OnInit} from '@angular/core';
import {DashboardService} from "../services/dashboard/dashboard.service";
import {Product} from "../models/product";
import {MessageService} from "primeng/api";
import {messageTypes} from "../enums/messageTypes";
import {Country} from "../models/country";
import {Currency} from "../models/currency";
import {combineLatest, filter, Subject} from "rxjs";

@Component({
	selector: 'app-dashboard',
	templateUrl: './dashboard.component.html',
	styleUrl: './dashboard.component.scss',
})
export class DashboardComponent implements OnInit {
	products: Product[] = [];
	allCountries: Country[] = [];
	selectedCountry: Country;
	allCurrencies: Currency[];
	productsLoaded = new Subject<boolean>();
	currenciesLoaded = new Subject<boolean>();

	constructor(
		private dashboardService: DashboardService,
		private messageService: MessageService,
	) {
		combineLatest([this.productsLoaded, this.currenciesLoaded]).pipe(
			filter(([val1, val2]) => val1 && val2)
		).subscribe(() => {
				this.convertAndFilterCurrencies();
			}
		)
	}

	ngOnInit() {
		this.productsLoaded.next(false);
		this.currenciesLoaded.next(false);

		this.getProducts();
		this.getCountries();
		this.getCurrencies();
	}

	getProducts(): void {
		this.dashboardService.getProducts().subscribe({
			next: (res) => {
				if (res.body) {
					this.products = res.body;
					this.productsLoaded.next(true);
				}
			},
			error: (e: Error) => {
				this.showError(e.message);
			}
		})
	}

	private getCountries() {
		this.dashboardService.getCountries().subscribe({
			next: (res) => {
				if (res.body) {
					this.allCountries = res.body;
					const uk = this.allCountries.find(x => x.countryCode == 'UK')
					this.selectedCountry = uk ? uk : this.allCountries[0];
				}
			},
			error: (e: Error) => {
				this.showError(e.message);
			}
		})
	}

	private getCurrencies() {
		this.dashboardService.getCurrencies().subscribe({
			next: (res) => {
				if (res.body) {
					this.allCurrencies = res.body;
					this.currenciesLoaded.next(true);
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
		this.convertAndFilterCurrencies();
	}

	convertAndFilterCurrencies(){


		for (const product of this.products) {
			const selectedCurrency = this.allCurrencies.find(x => x.currencyCode == this.selectedCountry.currencyCode);
			if (selectedCurrency) {
				const originalPrice = this.products.find(x => x.id == product.id)?.price;
				if (originalPrice) {
					product.displayPrice = originalPrice * selectedCurrency.exchangeRate
				}
			}
		}
	}
}
