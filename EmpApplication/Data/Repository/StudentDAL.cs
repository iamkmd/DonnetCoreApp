using EmpApplication.Models;
using Microsoft.Data.SqlClient;


namespace EmpApplication.Data.Repository
{
    public class StudentDAL : IStudentDAL
    {

        private readonly string connectionString;

        public StudentDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnectionString") ?? throw new
                ArgumentNullException(nameof(configuration), "Connection Not found");
        }


        public IEnumerable<Student> getAllStudents()
        {
            var list = new List<Student>();
            SqlConnection con = new SqlConnection(connectionString);
            using(SqlCommand cmd = new SqlCommand("Select * from Student" , con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read())
                {
                    Student stu = new Student
                    {
                        id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        City = reader.GetString(2)
                    };

                    list.Add(stu);
                }

            }

            return list;
        }


        public  Student? getById(int ? id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using(SqlCommand cmd = new SqlCommand("Select * from Student where @id = id",con))
            {
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                

                if (reader.Read())
                {
                    Student stu = new Student
                    {
                        id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        City = reader.GetString(2)
                    };

                    return stu;
                }
                else
                {
                    return null;
                }

               
            }
        }

        public void createStu(Student stu)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("Insert into Student (Name , City) values (@Name , @City)",con))
            {
                cmd.Parameters.AddWithValue("@Name", stu.Name);
                cmd.Parameters.AddWithValue("@City", stu.City);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }


        public void updateStu(Student stu , int? id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using(SqlCommand cmd = new SqlCommand("Update Student set Name = @Name , City = @City where id = @id",con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Name", stu.Name);
                cmd.Parameters.AddWithValue("@City", stu.City);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void deleteStu(int? id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using(SqlCommand cmd = new SqlCommand("Delete Student Where id = @id", con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
