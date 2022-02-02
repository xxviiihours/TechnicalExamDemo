import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, retry } from "rxjs/operators";
import { throwError } from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class Rest {
  private http: any;

  // private httpOptions = {
  //   headers: new HttpHeaders({
  //     'Content-Type': 'application/json; charset=utf-8'
  //   })
  // }
  private headers: HttpHeaders;
  constructor(httpClient: HttpClient) {
    this.http = httpClient;
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' })
  }

  send(method: string, url: string, data: any = null) {
    switch (method) {
      case 'POST':
        return this.http.post(url, data, this.headers)
          .pipe(retry(1), catchError(this.errorHandler));
      case 'GET':
        return this.http.get(url, this.headers)
          .pipe(retry(1), catchError(this.errorHandler));
      case 'PUT':
        return this.http.put(url, data, this.headers)
          .pipe(retry(1), catchError(this.errorHandler));
      case 'DELETE':
        return this.http.delete(url, this.headers)
          .pipe(retry(1), catchError(this.errorHandler));
      case 'PATCH':
        return this.http.patch(url, data, this.headers)
          .pipe(retry(1), catchError(this.errorHandler));
      default:
        return "Method not found."
    }
  }

  private errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
