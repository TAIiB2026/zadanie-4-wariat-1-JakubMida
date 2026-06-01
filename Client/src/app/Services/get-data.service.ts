import { inject, Injectable } from '@angular/core';
import { GetDataInterface } from '../interfaces/get-data.interface';
import { map, Observable } from 'rxjs';
import { ProduktClass } from '../classes/produkt.class';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetDataService implements GetDataInterface {
  private readonly http = inject(HttpClient);
  private readonly url = 'http://localhost:5013/api/products';

    Get(): Observable<ProduktClass[]> {
      return this.http.get<ProduktClass[]>(this.url).pipe(
        map(products => products.map(p => ({ ...p, dataWaznosci: new Date(p.dataWaznosci) })))
      );
    }
  
    GetByID(id: number): Observable<ProduktClass> {
      return this.http.get<ProduktClass>(`${this.url}/${id}`).pipe(
        map(p => ({ ...p, dataWaznosci: new Date(p.dataWaznosci) }))
      );
    }

    Delete(id: number): Observable<boolean> {
      return this.http.delete(`${this.url}/${id}`).pipe(
        map(() => true)
      );
    }
    
  constructor() { }
}
