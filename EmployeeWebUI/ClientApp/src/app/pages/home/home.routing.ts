import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { HomeComponent } from "./home.component";
import { ManageDepartmentsComponent } from "./manage-departments/manage-departments.component";
import { ManageEmployeesComponent } from "./manage-employees/manage-employees.component";

export const routes: Routes = [
  {
    path: "",
    component: HomeComponent,
    children: [
      { path: "", redirectTo: "dashboard", pathMatch: "full" },
      { path: "dashboard", component: DashboardComponent },
      { path: "manage-departments", component: ManageDepartmentsComponent },
      { path: "manage-employees", component: ManageEmployeesComponent }
    ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
