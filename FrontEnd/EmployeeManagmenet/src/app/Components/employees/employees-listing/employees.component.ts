import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeService } from '../../../core/services/employee.service';
import { Employee, EmployeesWithPagination } from '../../../core/interfaces/employee.interface';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { Table } from 'primeng/table';
import { SortEvent } from 'primeng/api';
import { Router } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { FaIconComponent } from '@fortawesome/angular-fontawesome';
import { faEye, faPencil, faTrash, faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-employees',
  standalone: true,
  imports: [TableModule, CommonModule, ButtonModule, FaIconComponent],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.scss'
})
export class EmployeesComponent implements OnInit {
  @ViewChild('dt') dt: Table = {} as Table;
  initialValue: Employee[] = [];

  // Font Awesome icons
  faEye = faEye;
  faPencil = faPencil;
  faTrash = faTrash;
  faPlus = faPlus;

  isSorted: boolean = false;
  statuses!: any[];
  loading: boolean = true;
  activityValues: number[] = [0, 100];
  searchValue: string | undefined;
  employeesWithPages: EmployeesWithPagination = {
    items: [],
    Records: 0,
    Pages: 0,
    PageIndex: 1,
    PageSize: 5
  };
  index: number = 1;
  size: number = 5;
  value: string = "";

  constructor(
    private _employeeService: EmployeeService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.loading = true;
    this._employeeService.getEmployees(this.index, this.size).subscribe({
      next: (response: EmployeesWithPagination) => {
        this.employeesWithPages = response;
        this.initialValue = [...response.items];
        this.loading = false;
      },
      error: (error: any) => {
        console.error('Error loading employees:', error);
        this.loading = false;
      }
    });
  }

  onPageChange(event: any): void {
    this.size = event.rows;
    this.index = event.first / event.rows + 1;
    this.loadEmployees();
  }

  customSort(event: SortEvent) {
    if (this.isSorted == null || this.isSorted === undefined) {
      this.isSorted = true;
      this.sortTableData(event);
    } else if (this.isSorted == true) {
      this.isSorted = false;
      this.sortTableData(event);
    } else if (this.isSorted == false) {
      this.isSorted = false;
      if (this.initialValue && this.initialValue.length > 0) {
        this.employeesWithPages.items = [...this.initialValue];
      }
      this.dt.reset();
    }
  }

  sortTableData(event: SortEvent) {
    if (event.data) {
      event.data.sort((data1, data2) => {
        let value1 = data1[event.field || ''];
        let value2 = data2[event.field || ''];
        let result = null;
        if (value1 == null && value2 != null) result = -1;
        else if (value1 != null && value2 == null) result = 1;
        else if (value1 == null && value2 == null) result = 0;
        else if (typeof value1 === 'string' && typeof value2 === 'string') result = value1.localeCompare(value2);
        else result = value1 < value2 ? -1 : value1 > value2 ? 1 : 0;

        return event.order ? result : -result;
      });
    }
  }

  navigateToCreate(): void {
    this.router.navigate(['/employees/create']);
  }

  navigateToUpdate(id: number): void {
    this.router.navigate(['/employees/update', id]);
  }


  deleteEmployee(id: number): void {
    if (confirm('Are you sure you want to delete this employee?')) {
      this._employeeService.deleteEmployee(id).subscribe({
        next: () => {
          this.loadEmployees();
        },
        error: (error) => {
          console.error('Error deleting employee:', error);
        }
      });
    }
  }
}
