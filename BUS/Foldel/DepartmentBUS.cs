using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Foldel;
using Model.Folder;

namespace BUS.Foldel
{
    public class DepartmentBUS
    {
        DepartmentDAL dal = new DepartmentDAL();
        public List<DepartmentBEL> ReadDepartmentList()
        {
            List<DepartmentBEL> IstDeparment = dal.ReadDepartmentList();
            return IstDeparment;
        }
    }
}
