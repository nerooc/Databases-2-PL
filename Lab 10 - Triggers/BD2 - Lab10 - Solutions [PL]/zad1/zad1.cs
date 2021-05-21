using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

public partial class Triggers{
    [Microsoft.SqlServer.Server.SqlTrigger (Name="Trigger", Target="test1", Event="FOR INSERT")]
    public static void Trigger(){
        using (SqlConnection cn = new SqlConnection("context connection=true")){
            cn.Open();
            string insertion = "INSERT INTO logs (user, content)" +
            "VALUES(USER, (SELECT CAST(el as VARCHAR(30)) FROM INSERTED))";
            SqlCommand sqlComm = new SqlCommand(insertion, cn);
            sqlComm.ExecuteNonQuery();
        }
    }
}