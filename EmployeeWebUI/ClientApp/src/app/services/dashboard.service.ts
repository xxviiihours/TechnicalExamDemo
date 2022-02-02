import { Injectable } from '@angular/core';
import { Rest } from './rest';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private dashboardUrl: string;

  constructor(private rest: Rest) {
    this.dashboardUrl = 'gateway/api/dashboard/status'
  }

  getAllStatus() {
    return this.rest.send('GET', this.dashboardUrl);
  }
}
