using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employee> GetAllEmployees();
        public bool AddEmployee(Employee employee);
        public bool IsertUpdate(Employee emp);
        public bool UpdateEmployee(Employee employee);
        public Employee GetElementById(int id);
        public bool DeleteEmployee(int id);
        public Employee LoginMethod(LoginModel loginModel);


        //get emp by name
        public Employee GetEmpByNames(string empName);
        public List<Employee> GetEmployeesByName(string empName);

    }
}
