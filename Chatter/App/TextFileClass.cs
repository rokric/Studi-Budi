using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class TextFileClass
    {
        private static string filePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private static string registrationDataFileName = "\\DataTextFiles\\registrationData.txt";
        private static string teacherSubjectsFileName = "\\DataTextFiles\\teacherSubjectsData.txt";
        private static string subjectsFileName = "\\DataTextFiles\\subjectsData.txt";
        public static bool CheckIfUserExists(string data)
        {
            bool found = false;

            using (StreamReader file = new StreamReader(filePath+ registrationDataFileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    if(line == data)
                    {
                        found = true;
                        break;
                    }
                }
                file.Close();
            }

            return found;
        }

        public static bool CheckIfUserNameIsAvailable(string userName)
        {
            bool found = true;

            using (StreamReader file = new StreamReader(filePath + registrationDataFileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    if (userName == data[0])
                    {
                        found = false;
                        break;
                    }
                }
                file.Close();
            }

            return found;
        }

        public static void AddData(string data)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath + registrationDataFileName, true))
                {
                    file.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error with a text file: ", ex);
            }
        }

        public static void WriteTeacherSubjects(List<Subject> subjects, string userName)
        {
            try
            {
                string[] text = File.ReadAllLines(filePath + teacherSubjectsFileName);
                File.Delete(filePath + teacherSubjectsFileName);

                using (StreamWriter writer = new StreamWriter(filePath + teacherSubjectsFileName, true))
                {
                    foreach(string line in text)
                    {
                        string[] data = line.Split(':');

                        if(data[0] == userName)
                        {
                            continue;
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }

                    foreach(Subject subject in subjects)
                    {
                        writer.WriteLine(userName + ":" + subject.title + ":" + subject.description);
                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error with a text file: ", ex);
            }
        }

        public static List<Subject> ReadTeacherSubjects(string userName)
        {
            List<Subject> subjects = new List<Subject>();

            using (StreamReader file = new StreamReader(filePath + teacherSubjectsFileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(':');

                    if (userName == data[0])
                    {
                        Subject subject = new Subject(data[1], data[2]);
                        subjects.Add(subject);
                    }
                }
                file.Close();
            }

            return subjects;

        }

        public static List<string> ReadSubjects()
        {
            List<string> subjects = new List<string>();

            using (StreamReader file = new StreamReader(filePath + subjectsFileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    subjects.Add(line);
                }
                file.Close();
            }

            return subjects;
        }
    }
}
