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
        public string nick { get; set; }
        public string password { get; set; }
        public string profession { get; set; }

        string connStr = "Data Source=studibudi.database.windows.net;Initial Catalog=Studi-Budi;Persist Security Info=True;User ID=studibudi;Password=Budistudi123";
        string commandText;
        string commandText2;

        #region Constructors
        public DataWriter()
        {
        }
        public DataWriter(string n)
        {
            nick =n;
        }
        public DataWriter(string n, string p )
            : this(n)
        {
             password = p;
        }
        public DataWriter(string n, string p, string pr)
             : this(n,p)
        {
            profession = pr;
        }
        #endregion
        public void InsertSubject(string title)// insert new subject into [teacher subject] table
        {
            //get userid by user nick
            // get user
            commandText = "INSERT INTO [dbo].[teacher subject]([userid],[subjectid]) VALUES(@userid, @subjectid)";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    command.Parameters.AddWithValue("@userid", );
                    command.Parameters.AddWithValue("@subjectid", password);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<string> GetSubjects()// get subjects list from 
        {
            List<string> subjects = new List<string>();
            string commandText ="SELECT [title] FROM [dbo].[subjects]";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                command.ExecuteNonQuery();
            }
            return subjects;
        }
        public List<string> GetTeachers()// get teachers list
        {
            List<string> subjects = new List<string>();
            string commandText = "SELECT [title] FROM [dbo].[subjects]";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                command.ExecuteNonQuery();
            }
            return subjects;
        }
        public User ReturnUser()
        {
            User user;
            if (profession.Equals("student"))
            {
                user = new Student(Encryptor.Encrypt(nick), Encryptor.Encrypt(password));
            }
            else
            {
                user = new Teacher(Encryptor.Encrypt(nick), Encryptor.Encrypt(password));
            }

            return user;
        }
        public void Write()
        {
            commandText ="INSERT INTO [dbo].[Table]([nick],[password],[profession]) VALUES(@nick, @password, @profession)";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    command.Parameters.AddWithValue("@nick", nick);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@profession", profession);
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool IsNickAvailable()
        {
            string commandText = string.Format("SELECT [nick] FROM [dbo].[Table] WHERE [nick]='{0}'",nick);
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                command.ExecuteNonQuery();
                if (command.ExecuteScalar() == null)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool IsLoginAccepted()
        {
            commandText = string.Format("SELECT [password]    FROM [dbo].[Table] WHERE [nick]='{0}'", nick);      
            commandText2 = string.Format("SELECT [profession] FROM [dbo].[Table] WHERE [nick]='{0}'", nick);      
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                SqlCommand command2 = new SqlCommand(commandText2, conn);
                command.ExecuteNonQuery();
                if (command.ExecuteScalar() == null) return false;
                       
                if (password==command.ExecuteScalar().ToString())
                    if (profession == command2.ExecuteScalar().ToString()) return true;
                return false;
            }
        }
        public bool IsServerConnected()
            {
                using (var l_oConnection = new SqlConnection(connStr))
                {
                    try
                    {
                        l_oConnection.Open();
                        return true;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
    }
}
