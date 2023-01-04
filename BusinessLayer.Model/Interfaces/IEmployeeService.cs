using System.Collections.Generic;
using BusinessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<CompanyInfo> GetAllEmployee();
        CompanyInfo GetEmployeeByCode(string employeeCode);
        bool SaveEmployeeDetails(EmployeeInfo companyInfo);
    }
}
