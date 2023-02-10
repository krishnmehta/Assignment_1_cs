using System;

namespace EmployeeExample
{
    public class Employee
    {
        // Initialize private Id, Name, DepartmentName
        private int Id;
        private string Name;
        private string DepartmentName;

        public delegate void MethodCalledEventHandler(string message); //using delegate
        public event MethodCalledEventHandler MethodCalled;

        public Employee(int id, string name, string departmentName)
        {
            Id = id;
            Name = name;
            DepartmentName = departmentName;
        }

        public int GetId()
        {
            //When method called GetId() will print
            OnMethodCalled("GetId() method called");
            return Id;
        }

        public string GetName()
        {
            //GetName() will print
            OnMethodCalled("GetName() method called");
            return Name;
        }

        public string GetDepartmentName()
        {
            //GetDepartment will print
            OnMethodCalled("GetDepartmentName() method called");
            return DepartmentName;
        }

        public void UpdateEmployee(int id)
        {
            Id = id;
        }

        public void UpdateEmployee(string name)
        {
            Name = name;
        }

        public void UpdateEmployee(string departmentName, int id = -1, string name = "")
        {
            if (id != -1)
                Id = id;
            if (name != "")
                Name = name;
            DepartmentName = departmentName;
        }

        protected virtual void OnMethodCalled(string message)
        {
            if (MethodCalled != null)
                MethodCalled(message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //User will enter details
            Console.WriteLine("Enter Emp ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Emp Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Emp Department Name: ");
            string departmentName = Console.ReadLine();

            Employee emp = new Employee(id, name, departmentName);
            emp.MethodCalled += MethodCalledEvent;

            Console.WriteLine("Emp ID: " + emp.GetId());
            Console.WriteLine("Emp Name: " + emp.GetName());
            Console.WriteLine("Emp Department Name: " + emp.GetDepartmentName());

        }

        private static void MethodCalledEvent(string message)
        {
            Console.WriteLine("\n" + message);
        }
    }
}
