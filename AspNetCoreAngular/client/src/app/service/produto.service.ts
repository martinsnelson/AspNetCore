import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Produto } from '../produto/produto';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  apiUrl = 'http://localhost:5000/v1/api/produto';

  constructor(private http: HttpClient) { }

  obterProdutos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.apiUrl + 'produto')
      .pipe(
        tap(_ => this.log('buscado produto')),
        catchError(this.handleError('obterProdutos', []))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      this.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }

  private log(message: string) {
    console.log(message);
  }
}
