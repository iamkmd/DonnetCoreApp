using EmpApplication.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;




namespace EmpApplication.Data.Repository
{
    public class EmployeeDAL : IEmployeeDAL
    {
        
        private readonly string connectionString;

        public EmployeeDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnectionString") ?? throw new
                 ArgumentNullException(nameof(configuration), "Connection string not found");
        }

      

        public IEnumerable<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand("spGetAllEmployees", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Employee emp = new Employee
                    {
                        EID = reader.GetInt32(0),
                        Ename=reader.GetString(1),
                        DeptId=reader.GetInt32(2),
                        Salary=reader.GetDecimal(3),
                        DOJ=reader.GetDateTime(4).Date,
                        
                    };
                    list.Add(emp);

                }
                

                

            }
            return list;
               
         }

         public Employee ? GetById(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using(SqlCommand cmd = new SqlCommand("spGetEmployeeById", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    Employee emp  = new Employee
                        {
                            EID = reader.GetInt32(0),
                            Ename = reader.GetString(1),
                            DeptId = reader.GetInt32(2),
                            Salary = reader.GetDecimal(3),
                            DOJ = reader.GetDateTime(4).Date
                        };

                    return emp;

                }
                else
                {
                    return null;
                }
               
            }

          
        }


        public void CreateEmp(Employee e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("spInserEmployeDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ename", e.Ename);
                cmd.Parameters.AddWithValue("@DeptId", e.DeptId);
                cmd.Parameters.AddWithValue("@Salary", e.Salary);
                cmd.Parameters.AddWithValue("DOJ", e.DOJ);

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }

        public void UpdateEmp(Employee e, int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("spUpdateEmployee", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                cmd.Parameters.AddWithValue("@EmpName", e.Ename);
                cmd.Parameters.AddWithValue("@Deptid", e.DeptId);
                cmd.Parameters.AddWithValue("@EmpSalary", e.Salary);
                cmd.Parameters.AddWithValue("@DateOfJoining", e.DOJ);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmp(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using(SqlCommand cmd = new SqlCommand("spDeleteEmployee" , con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

           
    }
}

