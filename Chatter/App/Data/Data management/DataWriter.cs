using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App
{
    public class DataWriter
    {
        public void write()
        {

            string connStr = "Data Source=studibudi.database.windows.net;Initial Catalog=Studi-Budi;Persist Security Info=True;User ID=studibudi;Password=Budistudi123";

            using (var conn = new SqlConnection(connStr))
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Table(nick,password,profession)
                    VALUES(@nick, @password, @profession)";
                    command.Parameters.AddWithValue("@nick", "smth");
                    command.Parameters.AddWithValue("@password", "smth");
                    command.Parameters.AddWithValue("@profession", 0);

                    conn.Open();
                }
            }
        }
        public void read() { }
            /*
             <appSettings>
                  <add key="provider" value="System.Data.SqlClient"/>

                  <add key ="connectionString" value="Data Source=studibudi.database.windows.net;Initial Catalog=Studi-Budi;Persist Security Info=True;User ID=studibudi;Password=***********"/>
             </appSettings>
  */
            /*
            string provider = ConfigurationManager.AppSettings
                ["provider"];
            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];
            DbProviderFactory factory =
                DbProviderFactories.GetFactory(provider);

            using (DbConnection connection =
                factory.CreateConnection())
            {
                if(connection==null)
                {
                    //somethin eroro
                }
                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if(command==null )
                {
                    //somethin eroro
                }
                command.Connection = connection;
                command.CommandText = ""

            }
            */

    }
}
