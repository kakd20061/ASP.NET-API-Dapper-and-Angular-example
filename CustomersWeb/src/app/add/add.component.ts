import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Customer } from '../Models/CustomerModel';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
})
export class AddComponent {
  constructor(private _apiService: ApiService, private _router: Router) {}
  GetCustomerFormData(data: any) {
    var model = {
      Name: data.name,
      LastName: data.lastname,
      Email: data.email,
      Phone: data.phone,
      Country: data.country,
      City: data.city,
      PostalCode: data.postalcode,
    };
    console.log(model);
    this._apiService
      .addData('https://localhost:7165/api/customers', model)
      .subscribe((res) => {
        this._router.navigate(['customers']);
      });
  }
}
