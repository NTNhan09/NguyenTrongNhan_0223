using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Folder
{
    public class EmployeeBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Db { get; set; }
        public bool Gd { get; set; }
        public string Pb { get; set; }
        public DepartmentBEL IdD { get; set; }
        public string IdDName
        {
            get { return IdD.Name; }
        }
    }
}
