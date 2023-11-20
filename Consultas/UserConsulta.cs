using Microsoft.Data.SqlClient;
using System.Data;
using TransporteSeguro.Models;

namespace TransporteSeguro.Consultas
{
    public class UserConsulta
    {
        private readonly IConfiguration configuration;

        private string conn;

        public UserConsulta(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("TransporteSeguroDb");
        }

        public IEnumerable<User> GetByValue(string value)
        {
            var userList = new List<User>();
            string email = value;
            using (var connection = new SqlConnection(conn))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Users
                                        WHERE Email LIKE @name+ '%'";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = email;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User();
                        user.Email = reader["Email"].ToString();
                        user.Password = reader["Password"].ToString();
                        userList.Add(user);
                    }
                }

            }
            return userList;

        }
    }
}
