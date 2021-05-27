using System;
using System.IO;
using System.Reflection;

namespace Ex3
{

    class NewUser 
    {
        public string MyProperty1;
        public string MyProperty2;
        public string MyProperty3;
        public string MyProperty4;
        public string MyProperty5;
        public string MyProperty6;


    }
    class Program
    {
        static string CreateDataFile<T>(T user)
        {
            var fis = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public);
            string data = String.Empty;
            foreach (var item in fis)
            {
                data+=$"#{item.Name}: {item.GetValue(user)}\n";
            }
            return data;
        }
        
        
        
        static void Main(string[] args)
        {
             var us = new NewUser()
            {
                MyProperty1 = "qwer",
                MyProperty2 = "qwer",
                MyProperty3 = "qwer",
                MyProperty4 = "qwer",
                MyProperty5 = "qwer",
                MyProperty6 = "qwer"
             };
            User user = new User("admin228");
            var txt = CreateDataFile(us);

            File.WriteAllText("data.user.txt", txt);

           // Console.WriteLine($"{user}");

            //File.AppendAllText("data.user.txt", $"#login: {user.login}\n");
            //File.AppendAllText("data.user.txt", $"#password: {user.password}\n");


        }
    }
}
