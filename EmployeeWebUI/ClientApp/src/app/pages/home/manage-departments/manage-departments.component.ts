import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DepartmentService } from '../../../services/department.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-manage-departments',
  templateUrl: './manage-departments.component.html',
  styleUrls: ['./manage-departments.component.scss']
})
export class ManageDepartmentsComponent implements OnInit {
  departments: any = [];
  departmentForm: FormGroup;
  private _departmentService: any;

  submitted = false;
  isViewedToEdit = false;
  isLoading = false;

  private departmentId: 0;

  constructor(departmentService: DepartmentService, formBuilder: FormBuilder) {
    this._departmentService = departmentService;
    this.departmentForm = formBuilder.group({
      name: ['', Validators.required],
      isActive: [true, Validators.required]
    })
  }
  @ViewChild('departmentModal') departmentElement: ElementRef;

  get f() { return this.departmentForm.controls }
  hideModal() {
    this.departmentElement.nativeElement.click();
  }

  ngOnInit() {
    this.loadDepartments();
  }

  loadDepartments() {
    this._departmentService
      .getAll()
      .subscribe((departments: any) => {
        this.departments = departments.data
      });
  }

  handleViewToEdit(data) {
    this.isViewedToEdit = true;
    this.departmentForm.patchValue({
      ...data
    });
    this.departmentId = data.departmentId
  }

  handleSubmit() {
    this.submitted = true;
    this.isLoading = true;

    if (!this.departmentForm.valid) {
      this.isLoading = false
      return;
    }

    const parsedData = {
      ...this.departmentForm.value
    }
    if (this.isViewedToEdit)
      this.handleSubmitUpdate(this.departmentId, parsedData);
    else
      this.handleSubmitSave(parsedData);

  }

  handleSubmitSave(data) {
    console.log(data);
    this._departmentService
      .save(data)
      .subscribe((data) => {
        Swal.fire(
          'Success!',
          'New Department has been saved!',
          'success'
        )
        this.loadDepartments();
        this.clearFields()
      });
  }

  handleSubmitUpdate(id, data) {
    console.log(data);
    this._departmentService
      .update(id, data)
      .subscribe(data => {
        Swal.fire(
          'Success!',
          'Department has been updated!',
          'success'
        )
        this.loadDepartments();
        this.clearFields()
      })
  }

  handleDelete(department) {
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
        this._departmentService
          .delete(department.departmentId)
          .subscribe(data => {
            Swal.fire(
              'Deleted!',
              `${department.name} has been deleted.`,
              'success'
            )
            this.loadDepartments();
            this.isLoading = false;
          })
      }
    })
  }
  clearFields() {
    this.isViewedToEdit = false;
    this.isLoading = false;
    this.submitted = false;
    this.departmentForm.reset();
  }
}
