using Employee.Contracts.Employee.Responses;
using Employee.Helper.CustomMapper;
using Employee.Helper.Pagination;
using Employee.Repository;
using MediatR;

namespace Employee.Features.Employee.Queries.GetAll
{
    public class GetAllEmployeesQuery : IRequest<PagingResponse<EmployeeResponse>>
    {
        public int Size { get; init; }
        public int Index { get; init; }
    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PagingResponse<EmployeeResponse>>
    {
        private readonly EmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<PagingResponse<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employeesWithPaging = await _employeeRepository.GetAll().CreatePagingAsync(request.Index, request.Size);
            var employeesResponse = employeesWithPaging.Items
                                    .Select(e => e.ToEmployeeResponse());
            var employyesResponseWithPages = new PagingResponse<EmployeeResponse>
            {
                Items = employeesResponse,
                PageIndex = employeesWithPaging.PageIndex,
                Pages = employeesWithPaging.Pages,
                PageSize = employeesWithPaging.PageSize,
                Records = employeesWithPaging.Records
            };
            return employyesResponseWithPages;
        }
    }
}
