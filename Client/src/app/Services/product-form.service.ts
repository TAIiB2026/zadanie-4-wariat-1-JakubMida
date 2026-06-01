import { inject, Injectable } from '@angular/core';
import { FormSubmitInterface } from '../interfaces/form-submit.interface';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductFormService implements FormSubmitInterface {
  private readonly http = inject(HttpClient);
  private readonly url = 'http://localhost:5013/api/Form';

  constructor() { }

  Post(nazwa: string, cena: number, data: Date): Observable<boolean> {
     const item = {
          nazwa: nazwa,
          cena: cena,
          dataWaznosci: data.toISOString().split('T')[0]
        };
      return this.http.post(this.url, item).pipe(map(() => true));
  }

  Put(id: number, nazwa: string, cena: number, data: Date): Observable<boolean> {
    const item = {
          id: id,
          nazwa: nazwa,
          cena: cena,
          dataWaznosci: data.toISOString().split('T')[0]
        };
      return this.http.put(`${this.url}/${id}`, item).pipe(map(() => true));
  }
}
