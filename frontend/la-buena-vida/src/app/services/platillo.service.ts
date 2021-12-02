import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Global } from './global';

@Injectable()
export class PlatilloService {
  public url: string;
  public headers: any;
  
  constructor(private _http: HttpClient) {
    this.url = Global.urlApi;
    this.headers = new HttpHeaders();
    this.headers.set('Content-Type', 'application/json');
    this.headers.set('Access-Control-Allow-Origin', '*');
    this.headers.set('Access-Control-Allow-Methods', 'GET,POST,OPTIONS,DELETE,PUT');
  }

  getPlatillos(): Observable<any> {

    return this._http.get(this.url + 'platillos/', {
        headers: this.headers,
      });
  }
  getPlatillo(id): Observable<any> {
    return this._http.get(this.url + 'platillos/' + id);
  }

  save(platillo): Observable<any> {
    let params = JSON.stringify(platillo);

    let headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this._http.post(this.url + 'platillos/', params, {
      headers: headers,
    });
  }

  actualizar(id, platillo): Observable<any> {
    return this._http.put(this.url + 'platillos/' + id, platillo);
  }

  delete(id): Observable<any> {
    return this._http.delete(this.url + 'platillos/' + id);
  }
}
