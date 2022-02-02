import { Injectable } from '@angular/core';
import { Rest } from './rest';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeeUrl: string;

  constructor(private rest: Rest) {
    this.employeeUrl = 'gateway/api/employees'
  }

  getAll() {
    return this.rest.send('GET', this.employeeUrl);
  }

  save(data) {
    return this.rest.send('POST', this.employeeUrl, { employee: data })
  }

  update(id, data) {
    return this.rest.send('PUT', this.employeeUrl + '/' + id, { id: id, employee: data });
  }

  delete(id) {
    return this.rest.send('DELETE', this.employeeUrl + '/' + id);
  }
}
