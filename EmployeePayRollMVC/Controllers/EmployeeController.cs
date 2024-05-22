using CommonLayer.Models;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayRollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }
        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeManager.GetAllEmployees().ToList();

            return View(lstEmployee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeManager.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeManager.GetElementById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Employee employee)
        
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeManager.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeManager.GetElementById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            employeeManager.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeManager.GetElementById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult EmpInsertUpdate(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeManager.GetElementById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult EmpInsertUpdate(Employee emp)
        {
            var res = employeeManager.IsertUpdate(emp);
            try
            {
                if (ModelState.IsValid)
                {
                    employeeManager.IsertUpdate(emp);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
                return View(emp);
            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Login(LoginModel model)
        {
            var result = employeeManager.LoginMethod(model);
            if (result == null)
            {
                return Content("Invalid Credentials");
            }
            else
            {

                HttpContext.Session.SetInt32("Id", result.EmployeeId);
                HttpContext.Session.SetString("name", result.Name);

                return RedirectToAction("GetEmpById");
            }
        }



        [HttpGet]
        public IActionResult GetEmpById(int id)
        {
            id = (int)HttpContext.Session.GetInt32("Id");
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeManager.GetElementById(id);
            if (employee == null)
            {
                return NotFound("Something went Wrong....");
            }
            return View(employee);
        }





        [HttpGet]
        public IActionResult GetEmpByName(string name)
        {
            //string names = HttpContext.Session.GetString("name");
             var names = employeeManager.GetEmpByNames(name);
            if (names == null)
            {
                return NotFound();
            }
            Employee emp = employeeManager.GetEmpByNames(name);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        //[HttpGet]
        //public IActionResult GetEmployeesByName()
        //{
           
        //    return View();
        //}

        [HttpGet]
        public IActionResult GetEmployeesByName(string empName)
        {
            var name=employeeManager.GetEmployeesByName(empName).Count();
            if (name == 0)
            {
                return NotFound();
            }

           
            
            if (name >1) {
                var res = employeeManager.GetEmployeesByName(empName);
                List<Employee> employee = new List<Employee>();

                return View(res);
            }

            return View();

        }

    }
}
