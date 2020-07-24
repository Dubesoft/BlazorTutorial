using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly AppDbContext appDbContext;
        public DepartmentRepository(AppDbContext appContext)
        {
            this.appDbContext = appContext;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }
    }
}
