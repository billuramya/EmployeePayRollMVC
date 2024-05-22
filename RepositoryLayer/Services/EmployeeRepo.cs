using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        string ConnectionString = @"Data Source=CHANDUU\SQLEXPRESS;initial catalog=MVC;Integrated Security=True;";
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(reader["EmpId"]);
                    employee.Name = reader["EmpName"].ToString();
                    employee.ProfileImage = reader["ProfileImage"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.Department = reader["Department"].ToString();
                    employee.Salary = Convert.ToInt32(reader["Salary"]);
                    employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    employee.Notes = reader["Notes"].ToString();
                    employees.Add(employee);

                }
                connection.Close();
                return employees;


            }
        }

        //To Add A new Recard 
        public bool AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("AddAllEmployees", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpName", employee.Name);
                    command.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    command.Parameters.AddWithValue("@Notes", employee.Notes);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return false;
            }
        }
        public bool UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@EmpName", employee.Name);
                    command.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@Notes", employee.Notes);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return false;

            }
        }
        public Employee GetElementById(int id)
        {
            Employee employee = new Employee();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("GetElementById", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpId", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        employee.EmployeeId = Convert.ToInt32(reader["EmpId"]);
                        employee.Name = reader["EmpName"].ToString();
                        employee.ProfileImage = reader["ProfileImage"].ToString();
                        employee.Gender = reader["Gender"].ToString();
                        employee.Department = reader["Department"].ToString();
                        employee.Salary = Convert.ToInt32(reader["Salary"]);
                        employee.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        employee.Notes = reader["Notes"].ToString();

                    }
                    return employee;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return null;
            }
        }
        public bool DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DeleteEmp", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    connection.Close();
                }
                return false;
            }
        }
        public bool IsertUpdate(Employee emp)
        {
            Employee employee = new Employee();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertUpdate", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    cmd.Parameters.AddWithValue("@id", emp.EmployeeId);
                    cmd.Parameters.AddWithValue("@name", emp.Name);
                    cmd.Parameters.AddWithValue("@ProfileName", emp.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", emp.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", emp.Notes);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally { connection.Close(); }

            }
        }
        //public bool DeleteEmployee(int id)
        //{

        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("DeleteEmp", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@EmpId", id);

        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
                
        //    }
        //    return true;

        //}
        public Employee LoginMethod(LoginModel loginModel)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("LoginEmployee", connection);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", loginModel.Id);
                cmd.Parameters.AddWithValue("@name", loginModel.Name);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(reader["EmpId"]);
                    emp.Name = reader["EmpName"].ToString();
                    return emp;

                }
                return null;

            }
        }





        //find an employee using employeename and take input of the name from session data

        public Employee GetEmpByNames(string empName)
        {
            Employee emp = new Employee();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {


                SqlCommand cmd = new SqlCommand("GetEmpByName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", empName);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        emp.EmployeeId = Convert.ToInt32(reader["EmpId"]);
                        emp.Name = reader["EmpName"].ToString();
                        emp.ProfileImage = reader["ProfileImage"].ToString();
                        emp.Gender = reader["Gender"].ToString();
                        emp.Department = reader["Department"].ToString();
                        emp.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        emp.Salary = Convert.ToInt32(reader["Salary"]);
                        emp.Notes = reader["Notes"].ToString();

                    }
                    return emp;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally { connection.Close(); }

            }
        }


        public List<Employee> GetEmployeesByName(string empName)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetEmpByName", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", empName);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.EmployeeId = Convert.ToInt32(reader["EmpId"]);
                        emp.Name = reader["EmpName"].ToString();
                        emp.ProfileImage = reader["ProfileImage"].ToString();
                        emp.Gender = reader["Gender"].ToString();
                        emp.Department = reader["Department"].ToString();
                        emp.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        emp.Salary = Convert.ToInt32(reader["Salary"]);
                        emp.Notes = reader["Notes"].ToString();
                        employees.Add(emp);
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
            return employees;
        }


    }
}

