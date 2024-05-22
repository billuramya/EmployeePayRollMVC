using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interface
{
   public interface IEmployeeManager
    {
        public IEnumerable<Employee> GetAllEmployees();
        public bool AddEmployee(Employee employee);
        public bool UpdateEmployee(Employee employee);
        public Employee GetElementById(int id);
        public bool DeleteEmployee(int id);
        public Employee LoginMethod(LoginModel loginModel);
        public bool IsertUpdate(Employee emp);

         public Employee GetEmpByNames(string empName);

        public List<Employee> GetEmployeesByName(string empName);


    }
}
