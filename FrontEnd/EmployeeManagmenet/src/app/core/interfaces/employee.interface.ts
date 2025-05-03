export interface CreateEmployeeRequest {
    firstName: string;
    lastName: string;
    email: string;
    position: string;
}

export interface UpdateEmployeeRequest {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    position: string;
}

export interface Employee{
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    position: string;
}

export interface EmployeesWithPagination
{
  items:Employee [];
  Records:number;
  Pages: number;
  PageIndex: number;
  PageSize:number
}
