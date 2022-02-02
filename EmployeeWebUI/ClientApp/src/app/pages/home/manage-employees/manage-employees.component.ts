import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { DepartmentService } from '../../../services/department.service';
import { EmployeeService } from '../../../services/employee.service';

@Component({
  selector: 'app-manage-employees',
  templateUrl: './manage-employees.component.html',
  styleUrls: ['./manage-employees.component.scss']
})
export class ManageEmployeesComponent implements OnInit {

  private _employeeService: any;
  private _departmentService: any;

  public employeeForm: FormGroup;

  employeeId: number;
  employees: any = [];
  departments: any = [];

  selectedDepartment: number;

  submitted = false;
  isLoading = false;
  isViewedToEdit = false;

  constructor(employeeService: EmployeeService,
    departmentService: DepartmentService, formBuilder: FormBuilder) {
    this._employeeService = employeeService;
    this._departmentService = departmentService;

    this.employeeForm = formBuilder.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      departmentId: [null, Validators.required],
      contactNumber: [''],
      emailAddress: ['', [Validators.email, Validators.required]],
      isActive: [true, Validators.required]
    })
  }

  @ViewChild('employeeModal') employeeElement: ElementRef;

  get f() { return this.employeeForm.controls }

  hideModal() {
    this.employeeElement.nativeElement.click();
  }

  ngOnInit(): void {
    this.loadEmployees();
    this.loadDepartments();
  }

  log(f) {
    console.log(f)
  }
  loadEmployees() {
    this._employeeService
      .getAll()
      .subscribe(employees => {
        this.employees = employees.data
      });
  }
  loadDepartments() {
    this._departmentService
      .getAll()
      .subscribe(departments => {
        this.departments = departments.data
      });
  }

  handleViewToEdit(data) {
    this.isViewedToEdit = true;
    this.employeeForm.patchValue({
      ...data
    })
    this.employeeId = data.employeeId
  }

  handleSubmit() {
    this.submitted = true
    this.isLoading = true

    if (!this.employeeForm.valid) {
      this.isLoading = false
      return;
    }
    const parsedData = {
      ...this.employeeForm.value
    }
    console.log(parsedData)
    if (this.isViewedToEdit) {
      this.handleSubmitUpdate(this.employeeId, parsedData)
    } else {
      this.handleSubmitSave(parsedData)
    }
  }

  handleSubmitSave(data) {
    this._employeeService
      .save(data)
      .subscribe(data => {
        Swal.fire(
          'Success!',
          'New Employee has been saved!',
          'success'
        )
        this.loadEmployees();
        this.clearFields()
      })
  }

  handleSubmitUpdate(id, data) {
    this._employeeService
      .update(id, data)
      .subscribe(data => {
        Swal.fire(
          'Success!',
          'Department has been updated!',
          'success'
        )
        this.loadEmployees();
        this.clearFields()
      })
  }

  handleDelete(employee) {
    this.isLoading = true
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        this._employeeService
          .delete(employee.employeeId)
          .subscribe(data => {
            Swal.fire(
              'Deleted!',
              `Employee ID: ${employee.employeeId} has been deleted.`,
              'success'
            )
            this.loadEmployees();
            this.clearFields()
          })
      }
    })
  }
  clearFields() {
    this.submitted = false;
    this.isLoading = false;
    this.isViewedToEdit = false;
    this.employeeForm.reset();
  }
}
