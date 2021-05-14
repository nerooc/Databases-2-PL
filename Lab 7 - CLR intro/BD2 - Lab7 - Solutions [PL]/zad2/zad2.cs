using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class LabCLR
{
    public static string GreetUser(string login, string server, string system)
    {
        string greet = "Witaj: {0}, dzisiaj jest: {1}, pracujesz na serwerze {2} w systemie {3}.";
        return string.Format(greet, login, DateTime.Now.ToString(), server, system);
    }
};