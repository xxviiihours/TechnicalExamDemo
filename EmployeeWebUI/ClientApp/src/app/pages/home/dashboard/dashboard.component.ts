import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../../services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  private _dashboardService: any;

  statusData: any = {};

  constructor(private dashboardService: DashboardService) {
    this._dashboardService = dashboardService;
  }

  ngOnInit(): void {
    this.loadEmployeeStatus();
  }

  loadEmployeeStatus() {
    this._dashboardService
      .getAllStatus()
      .subscribe(data => {
        this.statusData = data
      })
  }
}
