using Microsoft.Data.SqlClient;
using System.Data;

namespace SqlDataAccessApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FetchProducts();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void FetchProducts()
        {
            try
            {
                string query = "select * from products";

                using SqlConnection connection = new("server=joydip-pc\\sqlexpress;database=siemensdb;integrated security=true; trust server certificate=true");

                //SqlCommand command = new(query, connection);
                using SqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                //open the connection
                connection.Open();
                //status
                Console.WriteLine(connection.State.ToString());

                //execute the query
                SqlDataReader reader = command.ExecuteReader();

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //reader[0]
                        Console.WriteLine($"{reader["productid"]}, {reader["productname"]}, {reader["price"]}, {reader["productdescription"]}");
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
