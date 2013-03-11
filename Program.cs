using System;
using System.Diagnostics;
using System.Security;


namespace RunAs
{

public class Connect
    {
        string login;
        string password;
        string domain;

        public Connect(string login, string password, string domain)
        {
            this.login = login;
            this.password = password;
            this.domain = domain;
        }


        public void RunAs(string program)
        {
            try
            {
                ProcessStartInfo myProcess = new ProcessStartInfo(program);
                myProcess.UserName = login;
                //myProcess.Password = MakeSecureString(password); BIG Oops
                myProcess.Domain = Environment.MachineName; //domain
                myProcess.UseShellExecute = false;
                myProcess.Verb = "runas";
                Process.Start(myProcess);
            }
            catch
            {
                Console.WriteLine("Oops");
            }
        }

    }


class Program
    {
        static void Main(string[] args)
        {
            Connect con = new Connect("User", "Password", "WORKGROUP");
            con.RunAs("notepad");


        }
    }
}

