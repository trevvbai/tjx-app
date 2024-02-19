import {Injectable} from "@angular/core";
import {HttpClient, HttpHeaders, HttpResponse} from "@angular/common/http";
import {Observable} from "rxjs";
import {Product} from "../../models/product";
import {Country} from "../../models/country";

@Injectable({
	providedIn:"root"
})
export class DashboardService {

	dashboardRootUrl: string = "https://localhost:7219/api/dashboard"
	private readonly httpHeaders: HttpHeaders = new HttpHeaders();
	constructor(
		private http: HttpClient
	){
	}

	public getDashboardProducts() : Observable<HttpResponse<Product[]>>{
		return this.http.get<Product[]>(
			`${this.dashboardRootUrl}/products`,
			{observe: 'response', headers: this.httpHeaders, responseType: 'json'}
		);
	}

	public getDashboardCountries() : Observable<HttpResponse<Country[]>>{
		return this.http.get<Country[]>(
			`${this.dashboardRootUrl}/countries`,
			{observe: 'response', headers: this.httpHeaders, responseType: 'json'}
		);
	}

}
