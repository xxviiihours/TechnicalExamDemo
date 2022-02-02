import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ManageDepartmentsComponent } from './manage-departments/manage-departments.component';
import { ManageEmployeesComponent } from './manage-employees/manage-employees.component';
import { HomeRoutingModule } from './home.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';



@NgModule({
  declarations: [
    HomeComponent,
    DashboardComponent,
    ManageDepartmentsComponent,
    ManageEmployeesComponent
  ],
  imports: [
    HomeRoutingModule,
    CommonModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule

  ]
})
export class HomeModule { }
