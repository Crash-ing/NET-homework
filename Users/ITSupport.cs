using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public enum SpecializationType      // pārskaitāmā tips
    {
        Hardware,
        Software,
        Network,
        Security
    }

    public class ITSupport : User
    {
        public int ID { get; set; }
        public SpecializationType Specialization { get; set; }

        public Employee? EmployeeRef { get; set; }  // atsauce uz saistīto darbinieku objektu

        public ITSupport() { }  // tukšais konstruktors

        public ITSupport(string user_name, string email, int id, bool is_active, SpecializationType specialization)     // konstruktors ar parametriem
        {
            UserID = id;
            Email = email;
            UserName = user_name;
            IsActive = is_active;
            Specialization = specialization;
        }

        public ITSupport(Employee employee, SpecializationType specialization)    // konstruktors ar darbinieka objektu kā parametru
        {
            EmployeeRef = employee;
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            if (employee != null)
            {
                UserID = employee.UserID;
                UserName = employee.UserName;
                Email = employee.Email;
                IsActive = employee.IsActive;
            }
            Specialization = specialization;
        }

        public override string? ToString()  // Pārdefinēta metode ToString(), lai atgrieztu visu īpašību vērtības kā tekstu
        {
            return $"Username: {UserName}; Email: {Email}; ID: {UserID}; Active: {IsActive}; Specialization: {Specialization} ";
        }
    }
}
