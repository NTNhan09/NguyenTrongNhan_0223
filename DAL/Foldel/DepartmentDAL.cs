using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.Folder;

namespace DAL.Foldel
{
    public class DepartmentDAL : DBConnection
    {
        public List<DepartmentBEL> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Department_0223", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<DepartmentBEL> IstDepartment = new List<DepartmentBEL>();
            while (reader.Read())
            {
                DepartmentBEL department = new DepartmentBEL();
                department.IdD = reader["IdDepartment"].ToString();
                department.Name = reader["Name"].ToString();
                IstDepartment.Add(department);  
            }
            conn.Close();
            return IstDepartment;
        }

        public DepartmentBEL ReadDepartment(string id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Department_0223 WHERE IdDepartment = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentBEL IstDepartment = new DepartmentBEL();
            if (reader.HasRows && reader.Read())
            {
                IstDepartment.IdD = reader["IdDepartment"].ToString();
                IstDepartment.Name = reader["Name"].ToString();
            }
            conn.Close();
            return IstDepartment;
        }
    }
}

