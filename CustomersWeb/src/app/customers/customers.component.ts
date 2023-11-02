import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Customer } from '../Models/CustomerModel';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
})
export class CustomersComponent {
  customers: Customer[] = [];
  constructor(private _apiService: ApiService) {}

  ngOnInit(): void {
    this.getData();
  }

  getData(): void {
    this._apiService
      .getData('https://localhost:7165/api/customers')
      .subscribe((res) => {
        this.customers = res;
      });
  }
}
