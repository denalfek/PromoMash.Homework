import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {
  private apiUrl = 'https://localhost:7112'

  constructor(private http: HttpClient) { }

  get(countryId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/provinces?countryId=${countryId}`);
  }
}
