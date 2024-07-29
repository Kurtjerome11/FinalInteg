using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagementModels;

namespace ParkingManagementData
{
    public class SqlDbData
    {
        static string connectionString
       // = "Data Source =MHACEE\\SQLEXPRESS; Initial Catalog = ParkingManagement; Integrated Security = True;";
       = "Server=tcp:20.195.15.75,1433;Database=ParkingManagement;User Id=sa;Password=Kurtjerome11";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        static public void Connect()
        {
            sqlConnection.Open();
        }

        public static List<Park> GetParked()
        {
            string selectStatement = "SELECT plateNum, colorCar FROM users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<Park> parks = new List<Park>();

            while (reader.Read())
            {
                string plateNum = reader["plateNum"].ToString();
                string colorCar = reader["colorCar"].ToString();

                Park readUser = new Park();
                readUser.plateNum = plateNum;
                readUser.colorCar = colorCar;

                parks.Add(readUser);
            }

            sqlConnection.Close();

            return parks;
        }

        public static int AddCar(string plateNum, string colorCar)
        {
            int success;

            string insertStatement = "INSERT INTO users VALUES (@plateNum, @colorCar)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@plateNum", plateNum);
            insertCommand.Parameters.AddWithValue("@colorCar", colorCar);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;

        }

        public static void UpdateCar(string plateNum, string colorCar)
        {
            var updateStatment = $"UPDATE users SET colorCar = @colorCar WHERE plateNum = @plateNum";
            SqlCommand updateCommand = new SqlCommand(updateStatment, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@colorCar", colorCar);
            updateCommand.Parameters.AddWithValue("@plateNum", plateNum);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public static void DeleteCar(string plateNum)
        {
            string deleteStatement = $"DELETE FROM users WHERE plateNum = @plateNum";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@plateNum", plateNum);

            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

        }

    }
}