using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString zad2(SqlString expression){
        return new SqlString(DateTime.Now.ToString(expression.ToString()));
    }
};