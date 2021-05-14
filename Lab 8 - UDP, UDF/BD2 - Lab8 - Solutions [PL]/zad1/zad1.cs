using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

// Przepraszam, niestety nie zdążyłem się wyrobić z trzecim zadaniem z zestawu :(
public partial class StoredProcedures{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void zad1(SqlString pattern){
        SqlConnection connection = new SqlConnection("context connection=true");

        connection.Open();

        SqlCommand command = new SqlCommand(
            @"SELECT emp.EmployeeID, per_add.AddressLine1
                FROM HumanResources.Employee emp
	            JOIN HumanResources.EmployeeAddress emp_add ON emp.EmployeeID = emp_add.EmployeeID
	            JOIN Person.Address per_add ON emp_add.AddressID = per_add.AddressID
            ;",
            connection
        );

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read()){
            if (reader["AddressLine1"].ToString().Contains(pattern.ToString())){
                SqlContext.Pipe.Send(reader["EmployeeID"].ToString() + ", " + reader["AddressLine1"].ToString());
            }
        }
    }
};