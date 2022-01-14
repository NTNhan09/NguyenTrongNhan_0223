using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.Folder;

namespace DAL.Foldel
{
    public class EmployeeDAL:DBConnection
    {
        public List<EmployeeBEL> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee_0223", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeeBEL> IstEmployee = new List<EmployeeBEL>();
            DepartmentDAL depart = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeBEL em = new EmployeeBEL();
                em.Id = int.Parse(reader["IdEmployee"].ToString());
                em.Name = reader["Name"].ToString();
                em.Db = reader["DateBirth"].ToString();
                em.Gd = (bool)reader["Gender"];
                em.Pb = reader["PlaceBirth"].ToString();
                em.IdD = depart.ReadDepartment(reader["IdDepartment"].ToString());
                IstEmployee.Add(em);
            }
            conn.Close();
            return IstEmployee;
        }
        public void NewEmployee(EmployeeBEL em)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Employee_0223 values(@IdEmployee,@Name,@DateBirth,@Gender,@PlaceBirth,@IdDepartment)", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", em.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", em.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", em.Db));
            cmd.Parameters.Add(new SqlParameter("@Gender", em.Gd));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", em.Pb));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", em.IdD.IdD));
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void EditEmployee(EmployeeBEL em)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Employee_0223 set Name = @name, Db = @DateBirth, Gd = @Gender, Pb = @PlaceBirth, IdD = @IdDepartment where Id = @IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", em.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", em.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", em.Db));
            cmd.Parameters.Add(new SqlParameter("@Gender", em.Gd));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", em.Pb));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", em.IdD.IdD));
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteEmployee(EmployeeBEL em)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete Employee_0223 where Id = @IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", em.Id));
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
