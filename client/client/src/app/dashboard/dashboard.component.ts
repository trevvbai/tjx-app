import {Component, OnInit} from '@angular/core';
// import {DashboardService} from "../services/dashboard/dashboard-service";
import {HttpClientModule} from "@angular/common/http";
import {DashboardService} from "../services/dashboard/dashboard.service";
import {Product} from "../models/product";
import {NgForOf} from "@angular/common";
import {ButtonModule} from "primeng/button";

@Component({
  selector: 'app-dashboard',
  standalone: true,
	imports: [HttpClientModule, NgForOf, ButtonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
	providers: [DashboardService]
})
export class DashboardComponent implements OnInit{
	products: Product[] = [];

	constructor(
		private dashboardService: DashboardService
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
				console.log(e)}
		})
	}
}
