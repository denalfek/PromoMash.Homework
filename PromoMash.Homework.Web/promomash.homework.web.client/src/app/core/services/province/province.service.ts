import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {
  constructor(private http: HttpClient) { }

  get(countryId: string): Observable<any[]> {
    return this.http.get<any[]>(`${environment.promoMashWebApiUrl}/provinces?countryId=${countryId}`);
  }
}
