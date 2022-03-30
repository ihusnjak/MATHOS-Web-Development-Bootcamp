using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Common;
using EmployeeManagement.Model;
using EmployeeManagement.Repository.Common;


namespace EmployeeManagement.Repository
{
    public class TaskRepository : ITaskRepository
    {
        static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=employeeTaskManagementDB;Integrated Security=True";
        public async Task<List<TaskModelEntity>> GetAllTasksAsync(Paging paging, FilterTask filter, Sorting sort)
        {
            List<TaskModelEntity> tasks = new List<TaskModelEntity>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                StringBuilder commandString = new StringBuilder();
                commandString.Append("SELECT * FROM Task ");

                if (filter != null || filter.Complexity != 0)
                {
                    commandString.Append("WHERE 1=1 ");
                    if (!string.IsNullOrWhiteSpace(filter.Status))
                    {
                        commandString.Append("AND Status LIKE '" + filter.Status + "%' ");
                    }
                    if (!string.IsNullOrWhiteSpace(filter.Type))
                    {
                        commandString.Append("AND Type LIKE '" + filter.Type + "%' ");
                    }
                    if (filter.Complexity > 0 & filter.Complexity < 10)
                    {
                        commandString.Append("AND Age = " + filter.Complexity + " ");
                    }
                }
                if (sort != null)
                {
                    commandString.Append(" ORDER BY " + sort.SortByProp + " " + sort.SortOrder + " ");
                }
                if (paging != null)
                {
                    commandString.Append("OFFSET (" + paging.PageNumber + "-1) * " + paging.RecordsPerPAge + " ROWS ");
                    commandString.Append("FETCH NEXT " + paging.RecordsPerPAge + " ROWS ONLY");
                }

                SqlCommand cmd = new SqlCommand(commandString.ToString(), connection);
                await connection.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        TaskModelEntity task = new TaskModelEntity(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                        tasks.Add(task);
                    }
                    reader.Close();
                    connection.Close();
                    return tasks;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<TaskModelEntity> GetTaskByIdAsync(int id)
        {
            TaskModelEntity task = new TaskModelEntity();
            string commandText = "SELECT * FROM Task WHERE Task.Id = @Id;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                await conn.OpenAsync();
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    await reader.ReadAsync();
                    task.Id = reader.GetInt32(0);
                    task.Name = reader.GetString(1);
                    task.Status = reader.GetString(2);
                    task.Type = reader.GetString(3);
                    task.Complexity = reader.GetInt32(4);
                    conn.Close();
                    reader.Close();
                    return task;
                }
                else { return task; }
            }
        }

        public async Task PostTaskAsync(TaskModelEntity taskToPut)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                string commandText = "INSERT INTO Task (Name, Status, Type, Complexity) VALUES (@NAME, @STATUS, @TYPE, @COMPLEX);";
                var adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@NAME", taskToPut.Name);
                sqlCommand.Parameters.AddWithValue("@STATUS", taskToPut.Status);
                sqlCommand.Parameters.AddWithValue("@TYPE", taskToPut.Type);
                sqlCommand.Parameters.AddWithValue("@COMPLEX", taskToPut.Complexity);
                adapter.InsertCommand = sqlCommand;
                await conn.OpenAsync();
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                conn.Close();
            }
        }

        public async Task EditTaskAsync(int id, TaskModelEntity taskToEdit)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                string commandText = "UPDATE Task SET Name = @NAME, Status = @STATUS, Type = @TYPE, Complexity = @COMPLEXITY WHERE Id = @ID;";
                var adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.AddWithValue("@NAME", taskToEdit.Name);
                sqlCommand.Parameters.AddWithValue("@STATUS", taskToEdit.Status);
                sqlCommand.Parameters.AddWithValue("@TYPE", taskToEdit.Type);
                sqlCommand.Parameters.AddWithValue("@COMPLEXITY", taskToEdit.Complexity);
                sqlCommand.Parameters.AddWithValue("@ID", id);
                adapter.InsertCommand = sqlCommand;
                await conn.OpenAsync();
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                conn.Close();
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                string commandText = "DELETE FROM Task WHERE Task.Id = @Id;";
                var adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                adapter.InsertCommand = sqlCommand;
                await conn.OpenAsync();
                await adapter.InsertCommand.ExecuteNonQueryAsync();
                conn.Close();
            }


        }
    }
}
