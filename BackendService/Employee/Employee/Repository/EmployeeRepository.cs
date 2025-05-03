using Employee.InfraStructure;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repository
{
    public class EmployeeRepository
    {
        private readonly ApplicationContext _applicationContext;
        private readonly DbSet<Models.Employee> _employees;

        public EmployeeRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _employees = _applicationContext.Employees;
        }

        public async Task<Models.Employee> AddAsync(Models.Employee employee)
        {
            var result = await _employees.AddAsync(employee);
            return result.Entity;
        }
        public async Task<bool> UpdateAsync(Models.Employee updatedEmployee)
        {
            var updated = false;
            _employees.Update(updatedEmployee);
            updated = true;
            return updated;
        }

        public IQueryable<Models.Employee> GetAll()
        {
            return _employees;
        }

        public async Task<Models.Employee?> GetByIdAsync(int id)
        {
            return await _employees.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Delete(Models.Employee employee)
        {
            var deleted = false;
            _employees.Remove(employee);
            deleted = true;
            return deleted;
        }
        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
