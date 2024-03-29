﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace App
{
    public class DataWriter
    {
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Profession { get; set; }

        readonly string connStr = File.ReadAllText(DataManager.filePath+"\\Data\\Text Files\\connStr.txt");  
        string commandText;
        string commandText2;

        #region Constructors
        public DataWriter()
        {
        }

        //paramaters: string n - encrypted username
        public DataWriter(string n)
        {
            Nick =n;
        }
        public DataWriter(string n, string p )
            : this(n)
        {
             Password = p;
        }
        public DataWriter(string n, string p, string pr)
             : this(n,p)
        {
            Profession = pr;
        }
        #endregion
        public List<string> GetTeacherBySubject(string subjectTitle)
        {
           /* int subjectid = GetSubjectIdByTitle(subjectTitle);
            List<int> teacherId = GetTeacherIdBySubject(subjectid);
            List<string> teachers = GetNickByUserId(teacherId);
            return teachers;*/
            return GetNickByUserId(GetTeacherIdBySubject(GetSubjectIdByTitle(subjectTitle))); 
        }
        private List<string> GetNickByUserId(List<int> usersId)
        {
            List<string> nick = new List<string>();
            string tempCmd= "SELECT [nick] FROM [dbo].[user] WHERE [userid]='{0}'";
            foreach(int userId in usersId)
            {
                commandText = string.Format(tempCmd, userId);
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(commandText, conn);
                    using (IDataReader dr = command.ExecuteReader())
                    {
                          while (dr.Read())
                              nick.Add((dr[0].ToString()));
                    }
                    command.ExecuteNonQuery();
                }
            }
            return nick;
        }
        private List<int> GetTeacherIdBySubject(int subjectid)
        {
            List<int> teacherId = new List<int>();
            commandText = string.Format("SELECT [userid] FROM [dbo].[teaching] WHERE [subjectid]='{0}'", subjectid);
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        teacherId.Add(Int32.Parse(dr[0].ToString()));
                }
                command.ExecuteNonQuery();
            }
            return teacherId;
        }
        private int GetSubjectIdByTitle(string title)
        {
            int subjectid;
            commandText = string.Format("SELECT [subjectid] FROM [dbo].[subject] WHERE [title]='{0}'", title);
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                command.ExecuteNonQuery();
               // if (command.ExecuteScalar().ToString() != null)
               // {
                    subjectid = Int32.Parse(command.ExecuteScalar().ToString());
               // }  
            }
            return subjectid;
        }
        private string GetUserIdByNick(string nick)
        {
            string userid = "";
            commandText = string.Format("SELECT [userid] FROM [dbo].[User] WHERE [nick]='{0}'", nick);
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                command.ExecuteNonQuery();
                if (command.ExecuteScalar().ToString() != null)
                {
                    userid = command.ExecuteScalar().ToString();
                }
            }
            return userid;
        }
        public void InsertSubject(string title)// insert new subject into [teacher subject] table
        {
            string userid = GetUserIdByNick(Nick);
                int subjectid= GetSubjectIdByTitle(title);

            commandText = "INSERT INTO [dbo].[Teaching]([userid],[subjectid]) VALUES(@userid, @subjectid)";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    command.Parameters.AddWithValue("@userid", userid);
                    command.Parameters.AddWithValue("@subjectid", subjectid);
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public List<string> GetSubjects() 
        {
            List<string> subjects = new List<string>();
            string commandText = "SELECT [title] FROM [dbo].[Subject]";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                using(IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        subjects.Add(dr[0].ToString());
                }
                command.ExecuteNonQuery();
            }
            return subjects;
        }
        public List<string> GetTeachers()
        {
            List<string> teachersNames = new List<string>();
            string commandText = "SELECT [nick] FROM [dbo].[User] WHERE [profession]='teacher'";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        teachersNames.Add(dr[0].ToString());
                }
            }
            return teachersNames;
        }
        public User ReturnUser()
        {
            User user;
            if (Profession.Equals("student"))
            {
                user = new Student(Encryptor.Encrypt(Nick), Encryptor.Encrypt(Password));
            }
            else
            {
                user = new Teacher(Encryptor.Encrypt(Nick), Encryptor.Encrypt(Password));
            }

            return user;
        }
        public void Write()
        {
            commandText ="INSERT INTO [dbo].[User]([nick],[password],[profession]) VALUES(@nick, @password, @profession)";
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {
                    command.Parameters.AddWithValue("@nick", Nick);
                    command.Parameters.AddWithValue("@password", Password);
                    command.Parameters.AddWithValue("@profession", Profession);
                    command.ExecuteNonQuery();
                }
            }
        }
        public bool IsNickAvailable()
        {
            string commandText = string.Format("SELECT [nick] FROM [dbo].[User] WHERE [nick]='{0}'",Nick);
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
            commandText = string.Format("SELECT [password]    FROM [dbo].[User] WHERE [nick]='{0}'", Nick);      
            commandText2 = string.Format("SELECT [profession] FROM [dbo].[User] WHERE [nick]='{0}'", Nick);      
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                SqlCommand command2 = new SqlCommand(commandText2, conn);
                command.ExecuteNonQuery();
                if (command.ExecuteScalar() == null) return false;
                       
                if (Password==command.ExecuteScalar().ToString())
                    if (Profession == command2.ExecuteScalar().ToString()) return true;
                return false;
            }
        }

        //parameter: encrypted username
        //returns all subjects titles from database by teacher's encrypted username
        public List<string> GetSubjectsByTeacherName()
        {
            List<string> teacherSubjects = new List<string>();

            string commandText = 
                "SELECT [Subject].[title] FROM [dbo].[User], [dbo].[Teaching], [dbo].[Subject]" +
                "WHERE [User].[nick] = @nick and [Teaching].[userid] = [User].[userid] " +
                "and [Teaching].[subjectid] = [Subject].[subjectid]";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandText, conn);
                command.Parameters.AddWithValue("@nick", Nick);
                using (IDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        teacherSubjects.Add(dr[0].ToString());
                    }
                      
                }
            }

            return teacherSubjects;
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
