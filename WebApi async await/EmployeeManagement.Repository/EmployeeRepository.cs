using EmployeeManagement.Common;
using EmployeeManagement.Model;
using EmployeeManagement.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=employeeTaskManagementDB;Integrated Security=True";

        public async Task<List<Employee>> GetAllEmployeesAsync(Paging paging)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                StringBuilder commandString = new StringBuilder();
                commandString.Append("SELECT * FROM Employee ");


                if (paging != null)
                {
                    commandString.Append(" ORDER BY Age OFFSET ");
                    commandString.Append("(" + paging.PageNumber + "-1) * " + paging.RecordsPerPAge + " ROWS ");
                    commandString.Append("FETCH NEXT " + paging.RecordsPerPAge + " ROWS ONLY");
                }

                SqlCommand cmd = new SqlCommand(commandString.ToString(), connection);
                await connection.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        Employee employee = new Employee(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                        employees.Add(employee);
                    }
                    reader.Close();
                    connection.Close();
                    return employees;
                } else
                {
                    return null;
                }
            }
        }

        public async Task <Employee> GetEmployeeByIdAsync(int id)
        {
            Employee employee = new Employee();
            string commandText = "SELECT * FROM Employee WHERE Employee.Id = @Id;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                await conn.OpenAsync();
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if(reader.HasRows)
                {
                    await reader.ReadAsync();
                    employee.Id = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.GetString(2);
                    employee.Age = reader.GetInt32(3);
                    conn.Close();
                    reader.Close();
                    return employee;
                } else { return employee; }
            }
        }

        public async Task PostEmployeeAsync(Employee employeeToPost)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                string commandText = "INSERT INTO Employee (FirstName, LastName, Age) VALUES (@FN, @LN, @AGE);";
                var adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@FN", employeeToPost.FirstName);
                sqlCommand.Parameters.AddWithValue("@LN", employeeToPost.LastName);
                sqlCommand.Parameters.AddWithValue("@AGE", 18);
                adapter.InsertCommand = sqlCommand;
                await conn.OpenAsync();
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                conn.Close();
            }


        }

        public async Task DeleteEmployeeAsync(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                string commandText = "DELETE FROM Employee WHERE Employee.Id = @Id;";
                var adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                adapter.InsertCommand = sqlCommand;
                await conn.OpenAsync();
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                conn.Close();
            }


        }

        public async Task EditEmployeeAsync(int id,Employee employeeToEdit) {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                string commandText = "UPDATE Employee SET FirstName = @FN, LastName = @LN WHERE Id = @ID;";
                var adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@FN", employeeToEdit.FirstName);
                sqlCommand.Parameters.AddWithValue("@LN", employeeToEdit.LastName);
                sqlCommand.Parameters.AddWithValue("@ID", id);
                adapter.InsertCommand = sqlCommand;
                await conn.OpenAsync();
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                conn.Close();
            }
        }

    }
}
