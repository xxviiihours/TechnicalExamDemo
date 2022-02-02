import { Injectable } from '@angular/core';
import { Rest } from './rest';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private departmentUrl: string;

  constructor(private rest: Rest) {
    this.departmentUrl = 'gateway/api/departments';
  }

  getAll() {
    return this.rest.send('GET', this.departmentUrl);

  }

  save(data) {
    return this.rest.send('POST', this.departmentUrl, { department: data });
  }

  delete(id) {
    return this.rest.send('DELETE', this.departmentUrl + "/" + id)
  }

  update(id, data) {
    return this.rest.send('PUT', this.departmentUrl + "/" + id, { id: id, department: data })
  }
}
