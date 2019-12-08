using System.Collections.Generic;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAdapterDataTable
{

    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Data Source=studibudi.database.windows.net;Initial Catalog=Studi-Budi;Persist Security Info=True;User ID=studibudi;Password=Budistudi123";



            string name = "parodyk";
            string lastname = "viska";
            ExtensionMethods.PrintDataOnNameAndLasName(connectionString, name, lastname);

            name = "Juozas";
            lastname = "Kavaliauskas";
            int metai = 20;
            int raktas = 9;
            //ExtensionMethods.InsertDataIntoTable(connectionString, name, lastname, metai);

            ExtensionMethods.ChangeData(connectionString, metai, raktas);

            //ExtensionMethods.Deleterow(connectionString, raktas);


            /*
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "SELECT * FROM dbo.Laikina;", connection);
                connection.Open();

                SqlDataReader rdr = command.ExecuteReader();

                while (rdr.HasRows)
                {
                    Console.WriteLine("\t{0}\t{1}", rdr.GetName(0),
                        rdr.GetName(1));
                    while (rdr.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", rdr.GetValue(0),
                            rdr.GetValue(1), rdr.GetValue(2),rdr.GetValue(3));
                    }
                    rdr.NextResult();
                }
                rdr.Close();

                string queryString ="SELECT * FROM [dbo].Laikina;";


                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionString);
                adapter.UpdateCommand = new SqlCommand(
                "UPDATE Laikina SET pavarde = @pavarde " +
                "WHERE Id = @Id ", connection);

                adapter.UpdateCommand.Parameters.Add(
                   "@pavarde", SqlDbType.NVarChar, 10, "pavarde");

                SqlParameter parameter = adapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int);
                parameter.SourceColumn = "Id";
                parameter.SourceVersion = DataRowVersion.Original;


                DataTable categoryTable = new DataTable();
                adapter.Fill(categoryTable);

                

                DataRow categoryRow = categoryTable.Rows[0];
                categoryRow["pavarde"] = "hk";

                adapter.Update(categoryTable);

                Console.WriteLine("Rows after update.");

                foreach (DataRow row in categoryTable.Rows)
                {
                    {
                        Console.WriteLine("\t{0} \t{1} \t{2} \t{3}", row[0], row[1], row[2], row[3]);
                    }
                }
                


            }

            */


        }

    }
    static class ExtensionMethods
    {

        public static void PrintRows(DataSet dataSet)
        {

            // For each table in the DataSet, print the row values.
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine(table.ToString());
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.Write(row[column] + "  ");
                    }
                    Console.WriteLine("");
                }
            }
        }

        public static void PrintRowsD(DataTable dataTable)
        {
                Console.WriteLine("Rows after update.");
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        Console.Write(row[column] + "  ");
                    }
                    Console.WriteLine("");
                 }
        }
        public static void PrintDataOnNameAndLasName(string connectionString, string name, string lastname)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connectionString;
            cn.Open();

            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand command = new SqlCommand
            {
                Connection = cn,
                CommandType = CommandType.Text
            };

            if (name.Equals("parodyk") && lastname.Equals("viska"))
            {
                command.CommandText="SELECT * From dbo.Laikina ";
            }
            else
            {
                command.CommandText = "SELECT * From dbo.Laikina WHERE vardas=@FN and pavarde=@LN";

                command.Parameters.AddWithValue("@Fn", name);
                command.Parameters.AddWithValue("@LN", lastname);
            }
            

            da.SelectCommand = command;

            DataSet ds = new DataSet();
            da.Fill(ds, "Laikina");
            
            PrintRows(ds);

            cn.Close();
            da.Dispose();
            ds.Clear();
        }

        public static void ChangeData(string connectionString, int metai, int raktas)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connectionString;
            cn.Open();


            SqlCommand sql = new SqlCommand();
            sql.Connection = cn;
            sql.CommandType = CommandType.Text;
            sql.CommandText = " UPDATE dbo.Laikina SET metai = @metai WHERE Id = @Id ";


            sql.Parameters.AddWithValue("@metai", metai);
            sql.Parameters.AddWithValue("@Id", raktas);

            int i =sql.ExecuteNonQuery();


            if (i > 0)
            {

                Console.WriteLine("pavyko!! Duomenys po pakeitimo ");
                PrintDataOnNameAndLasName(connectionString, "parodyk", "parodyk");
            }
            else Console.WriteLine("nepavyko");

            cn.Close();
        }

        /*public static void Deleterow(string connectionString, int raktas)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connectionString;
            cn.Open();


            /*SqlCommand sql = new SqlCommand();
            sql.Connection = cn;
            sql.CommandType = CommandType.Text;
            sql.CommandText = " SELECT * FROM dbo.Laikina WHERE Id = @Id ";

            sql.Parameters.AddWithValue("@Id", raktas);///

            SqlDataAdapter da = new SqlDataAdapter(" SELECT * FROM dbo.Laikina WHERE Id = @Id ", cn);
            da.SelectCommand.Parameters.AddWithValue("@Id", raktas);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);

            DataSet ds = new DataSet("Laikina");
            da.Fill(ds, "Laikina");
            DataRow row = ds.Tables["Laikina"].Rows[0];
            ds.Tables["Laikina"].Rows.Remove(row);
            da.Update(ds, "Laikina");


                Console.WriteLine("pavyko!! Duomenys po pakeitimo ");
                PrintDataOnNameAndLasName(connectionString, "parodyk", "parodyk");


            cn.Close();
        }*/
        public static void  InsertDataIntoTable(string connectionString, string name, string lastname, int metai)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = connectionString;
            cn.Open();

            SqlCommand insert = new SqlCommand();
            insert.Connection = cn;
            insert.CommandType = CommandType.Text;
            insert.CommandText = "INSERT INTO dbo.Laikina (vardas,pavarde,metai) VALUES (@FN,@LN,@Y)";

            insert.Parameters.Add(new SqlParameter("@FN", SqlDbType.VarChar, 20, "vardas"));
            insert.Parameters.Add(new SqlParameter("@LN", SqlDbType.VarChar, 20, "pavarde"));
            insert.Parameters.Add(new SqlParameter("@Y", SqlDbType.Int, 1, "metai"));

            SqlDataAdapter da = new SqlDataAdapter("SELECT * From dbo.Laikina", cn);
            da.InsertCommand = insert;

            DataSet ds = new DataSet();
            da.Fill(ds, "Laikina");

            DataTable dt = ds.Tables["Laikina"];

            DataRow newRow = dt.NewRow();
            newRow["vardas"] = name;
            newRow["pavarde"] = lastname;
            newRow["metai"] = metai;
            dt.Rows.Add(newRow);

            PrintRows(ds);

            da.Update(ds,"Laikina");
            cn.Close();
            da.Dispose();


        }



    }
}

