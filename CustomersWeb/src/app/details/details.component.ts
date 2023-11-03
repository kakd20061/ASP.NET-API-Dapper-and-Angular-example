import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Customer } from '../Models/CustomerModel';
import { Router } from '@angular/router';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent {
  id: number = 0;
  customer: Customer = {} as Customer;

  customerForm = new FormGroup({
    name: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    phone: new FormControl(''),
    country: new FormControl(''),
    city: new FormControl(''),
    postalCode: new FormControl(''),
  });

  constructor(
    private route: ActivatedRoute,
    private _apiService: ApiService,
    private _router: Router
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.id = +params['id']; // (+) converts string 'id' to a number
    });

    this._apiService
      .getDataById('https://localhost:7165/api/customers', this.id)
      .subscribe((res) => {
        this.customer = res;
        this.customerForm.setValue({
          name: this.customer.name,
          lastName: this.customer.lastName,
          email: this.customer.email,
          phone: this.customer.phone,
          country: this.customer.country,
          city: this.customer.city,
          postalCode: this.customer.postalCode,
        });
      });
  }

  UpdateData(data: any) {
    var model = {
      Name: data.name,
      LastName: data.lastname,
      Email: data.email,
      Phone: data.phone,
      Country: data.country,
      City: data.city,
      PostalCode: data.postalcode,
    };
    this._apiService
      .updateData('https://localhost:7165/api/customers', this.id, data)
      .subscribe((res) => {
        this._router.navigate(['customers']);
      });
  }

  DeleteData() {
    this._apiService
      .deleteData('https://localhost:7165/api/customers', this.id)
      .subscribe((res) => {
        this._router.navigate(['customers']);
      });
  }
}
