using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProgramManagementSystem_V2
{
    internal class FitnessProgramRepository
    {
        public string ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Initial Catalog=FitnessProgramManagement";
        public void AddProgram()
        {
            try
            {
                Console.Write("Enter FitnessProgram ID: ");
                string programId = Console.ReadLine();
                Console.Write("Enter FitnessProgram Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter FitnessProgram Duration: ");
                string duration = Console.ReadLine();
                Console.Write("Enter FitnessProgram Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO FitnessPrograms (FitnessProgramId, Title, Duration, Price) VALUES (@FitnessProgramId, @Title, @Duration, @Price);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FitnessProgramId", programId);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Duration", duration);
                        command.Parameters.AddWithValue("@Price", price);
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("FitnessProgram added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void UpdateProgram()
        {
            try
            {
                Console.Write("Enter the FitnessProgram ID: ");
                int programId = int.Parse(Console.ReadLine());
                Console.Write("Enter FitnessProgram Title: ");
                string title = Console.ReadLine();
                Console.Write("Enter FitnessProgram Duration: ");
                string duration = Console.ReadLine();
                Console.Write("Enter FitnessProgram Price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO FitnessPrograms (FitnessProgramId, Title, Duration, Price) VALUES (@FitnessProgramId, @Title, @Duration, @Price);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FitnessProgramId", programId);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Duration", duration);
                        command.Parameters.AddWithValue("@Price", price);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeleteProgram()
        {
            Console.Write("Enter the FitnessProgram ID: ");
            int programId = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM FitnessPrograms WHERE FitnessProgramId = @FitnessProgramId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FitnessProgramId", programId);
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
            Console.WriteLine("FitnessProgram deleted successfully.");
        }

        public string GetProgramById()
        {
            try
            {
                Console.Write("Enter the FitnessProgram ID: ");
                int programId = int.Parse(Console.ReadLine());
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELETE * FROM FitnessPrograms WHERE FitnessProgramId = @FitnessProgramId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FitnessProgramId", programId);
                        SqlDataReader reader = command.ExecuteReader();
                        return $"Fitness Program ID: {reader["FitnessProgramId"]}, Title: {reader["Title"]}, Duration: {reader["Duration"]}, Price: {reader["Price"]}";
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }

        }

        public string GetAllProgram()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELETE * FROM FitnessPrograms";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        return $"Fitness Program ID: {reader["FitnessProgramId"]}, Title: {reader["Title"]}, Duration: {reader["Duration"]}, Price: {reader["Price"]}";
                    }
                }
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
    }
}
