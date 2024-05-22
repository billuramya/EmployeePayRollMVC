using CommonLayer.Models;
using ManagerLayer.Interface;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Services
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepo employeeRepo;
        public EmployeeManager(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeeRepo.GetAllEmployees();
        }
        public bool AddEmployee(Employee employee)
        {
           return employeeRepo.AddEmployee(employee);
        }
        public bool UpdateEmployee(Employee employee)
        {
            return employeeRepo.UpdateEmployee(employee);
        }
        public Employee GetElementById(int id)
        {
            return employeeRepo.GetElementById(id);
        }
        public bool DeleteEmployee(int id)
        {
            return employeeRepo.DeleteEmployee(id);
        }
        public bool IsertUpdate(Employee emp)
        {
            return employeeRepo.IsertUpdate(emp);
        }
        public Employee LoginMethod(LoginModel loginModel)
        {
            return employeeRepo.LoginMethod(loginModel);
        }




        public Employee GetEmpByNames(string empName)
        {
            return employeeRepo.GetEmpByNames(empName);
        }

        public List<Employee> GetEmployeesByName(string empName)
        {
            return employeeRepo.GetEmployeesByName(empName);
        }



    }
}
