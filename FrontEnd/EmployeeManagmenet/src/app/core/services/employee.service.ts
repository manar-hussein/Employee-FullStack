import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { CreateEmployeeRequest, UpdateEmployeeRequest, Employee, EmployeesWithPagination } from '../interfaces/employee.interface';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  constructor(private apiService: ApiService) {}
  getEmployees(index:number , size:number): Observable<EmployeesWithPagination> {
    return this.apiService.get<EmployeesWithPagination>(`employees?index=${index}&size=${size}`);
  }

  getEmployee(id: number): Observable<Employee> {
    return this.apiService.get<Employee>(`employees/${id}`);
  }

  createEmployee(employee: CreateEmployeeRequest): Observable<Employee> {
    return this.apiService.post<Employee>('employees', employee);
  }

  updateEmployee(id: number, employee: UpdateEmployeeRequest): Observable<Employee> {
    return this.apiService.put<Employee>(`employees/${id}`, employee);
  }

  deleteEmployee(id: number): Observable<void> {
    return this.apiService.delete<void>(`employees/${id}`);
  }
}
