import { Routes } from '@angular/router';
import { EmployeesComponent } from './Components/employees/employees-listing/employees.component';
import { CreateEmployeeComponent } from './Components/employees/create-employee/create-employee.component';
import { UpdateEmployeeComponent } from './Components/employees/update-employee/update-employee.component';

export const routes: Routes = [
  { path: 'employees', component: EmployeesComponent },
  { path: 'employees/create', component: CreateEmployeeComponent },
  { path: 'employees/update/:id', component: UpdateEmployeeComponent },
  { path: '', redirectTo: '/employees', pathMatch: 'full' }
];
