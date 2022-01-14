using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Foldel;
using Model.Folder;

namespace BUS.Foldel
{
    public class EmployeeBUS
    {
        EmployeeDAL dal = new EmployeeDAL();
        public List<EmployeeBEL> ReadEmployee()
        {
            List<EmployeeBEL> Employees = dal.ReadEmployee();
            return Employees;
        }

        public void NewEmployee(EmployeeBEL employee)
        {
            dal.NewEmployee(employee);
        }

        public void DeleteEmployee(EmployeeBEL employee)
        {
            dal.DeleteEmployee(employee);
        }

        public void EditEmployee(EmployeeBEL employee)
        {
            dal.EditEmployee(employee);
        }
    }
}
