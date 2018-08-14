using System;
using System.IO;
using System.Collections.Generic;

namespace GMailUnitTestProject.PageObject
{
    class GetData
    {
        List<Tuple<string, string>> dataList = new List<Tuple<string, string>>();
        FileStream fin;
        string s;
        string username;
        string password;
        string fileName = "data.txt";

        public List<Tuple<string, string>> GetUsersData()
        {
            try
            {
                fin = new FileStream(fileName, FileMode.Open);
                Console.WriteLine("The file is opened");
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine("The file is not found " + exc.Message);
                
            }
            StreamReader fstr_in = new StreamReader(fin);
            while ((s = fstr_in.ReadLine()) != null)
            {
                string[] data = s.Split(' ');
                if (data.Length >= 1)
                {
                    username = data[0];
                    password = data[1];
                    dataList.Add(new Tuple<string, string>(username, password));
                }
            }
            fstr_in.Close();
            return dataList;
        }
    }
}
