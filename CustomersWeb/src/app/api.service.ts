import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private _http: HttpClient) {}

  getData(url: string) {
    return this._http.get<any>(`${url}`);
  }
  getDataById(url: string, id: number) {
    return this._http.get<any>(`${url}/${id}`);
  }
  addData(url: string, form: any) {
    return this._http.post<any>(`${url}`, form);
  }
  updateData(url: string, id: number, form: any) {
    return this._http.put<any>(`${url}/${id}`, form);
  }
  deleteData(url: string, id: number) {
    return this._http.delete<any>(`${url}/${id}`);
  }
}
