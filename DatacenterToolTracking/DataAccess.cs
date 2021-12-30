using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace DatacenterToolTracking
{
    class DataAccess
    {
        public string getSqlConnString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-D5A59AV\SQLDCTOOLTRACKER";   // update me
            builder.UserID = "sa";              // update me
            builder.Password = "capstone1!";      // update me
            builder.InitialCatalog = "BoydtonToolLocations";

            return builder.ConnectionString;
        }

        public List<Tool> GetTools(string ToolName)
        {
            //using statement allows open and closes connection 
            using (IDbConnection connection = new SqlConnection(getSqlConnString()))
            {
                connection.Open();

                var output = connection.Query<Tool>($"select * from BnTools where ToolName = '{ToolName}' ").ToList();
                return output;

            }
        }

        public void InsertTool(int Id, string Name, string Type, string Location, string Status)
        {
            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            using (SqlConnection connection = new SqlConnection(getSqlConnString()))
            {
                connection.Open();
                Console.WriteLine("Done.");


                //connection.Execute("dbo.BnTools @Id, @ToolName, @ToolType, @Location, @Status", tools);

                connection.Execute($"INSERT INTO dbo.BnTools (Id, ToolName, ToolType, Location, Status)" +
                    $"VALUES ('{Id}', '{Name}', '{Type}', '{Location}', '{Status}')");


            }
        }
    }
}
