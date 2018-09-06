using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using MultiTenant05.Models;

namespace MultiTenant05.DataAccess
{
    public class TenantDataProvider : IDataConnection
    {
        public TenantDataProvider()
        {

        }

        public Tenant GetTenant(string host)
        {
            // Verify the host name.
            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentNullException("host");
            }

            // If the host name has a port number, strip it out.
            int portNumberIndex = host.LastIndexOf(':');
            if (portNumberIndex > 0)
            {
                host = host.Substring(0, portNumberIndex);
            }

            Tenant output = new Tenant();
            Object test = new Object();


            string sql = "Select * From dbo.Tenant Where Host = @host;";

            // TODO - What happes to the output, how is it put into the Tenant

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString("DefaultConnection")))
            {
                //output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
                test = connection.QuerySingleOrDefault(sql, new { host });

                output = connection.QuerySingleOrDefault<Tenant>(sql, new { host });

                /*dynamic result = connection.Query<dynamic>(sql, host).First();

                output.Id = Console.WriteLine(result.Id);
                output.Name = Console.WriteLine(result.Name);
                output.Host = Console.WriteLine(result.Host);
                output.Title = Console.WriteLine(result.Title);
                output.Theme = Console.WriteLine(result.Theme);*/

                return output;
            }

            string CnnString(string name)
            {
                return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }

            


            /*// Get an instance of the LINQ to SQL database.
            DataClassesDataContext database = new DataClassesDataContext();

            // From the list of tenants in the LINQ to SQL database
            // select the tenant where the tenant host matches the 
            // host name.
            Tenant result = (from tenant in database.Tenants
                             where tenant.Host == host
                             select tenant).SingleOrDefault();

            // Return the selected tenant or <null> if a matching
            // tenant was not found.
            return result;*/
        }
    }
}



/**public class SqlConnector : IDataConnection
    {
        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAddress);
                p.Add("@CellphoneNumber", model.CellphoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }

        }

        

        /// <summary>
        /// Saves a prizes to the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns>returns the price information, including the unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;

            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            return output;
        }
    }**/
