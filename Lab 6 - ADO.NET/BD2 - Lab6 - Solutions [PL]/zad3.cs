using System;
using System.Data.SqlClient;
namespace Lab06.Examples
{
    class Lab06Zad3
    {
        static void Main(string[] args)
        {
            string sqlconnection = @"DATA SOURCE=MSSQLServer;" +
            "INITIAL CATALOG=Lab6db; INTEGRATED SECURITY=SSPI;";
            SqlConnection connection = new SqlConnection(sqlconnection);
            try
            {
                connection.Open();

                // ZADANIE 3A
                string create_databases_query = "EXEC create_tables";
                SqlCommand command = new SqlCommand(create_databases_query, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Stworzono tabele!\n");

                // ZADANIE 3B (Bardzo przepraszam, niestety nie zdazylbym z CSV, dlatego wersja light)
                string insertCommand = @"INSERT INTO student (id, fname, lname) VALUES (1, 'Tomasz', 'Gajda'); 
                    INSERT INTO student (id, fname, lname) VALUES (2, 'Test', 'Testowski');
	                INSERT INTO student (id, fname, lname) VALUES (3, 'Ala', 'Zkraincyczarów');

	                INSERT INTO wykladowca (id, fname, lname) VALUES (1, 'Jan', 'Piotrowski');
	                INSERT INTO wykladowca (id, fname, lname) VALUES (2, 'Piotr', 'Janowski');
	                INSERT INTO wykladowca (id, fname, lname) VALUES (3, 'Jotr', 'Pianowski');

	                INSERT INTO przedmiot (id, name) VALUES (1, 'Programowanie równoległe');
	                INSERT INTO przedmiot (id, name) VALUES (2, 'Sieci komputerowe');
	                INSERT INTO przedmiot (id, name) VALUES (3, 'Fizyka');

	                INSERT INTO grupa (id_wykl, id_stud, id_przed) VALUES (1,1,1);
	                INSERT INTO grupa (id_wykl, id_stud, id_przed) VALUES (1,2,1);
	                INSERT INTO grupa (id_wykl, id_stud, id_przed) VALUES (1,3,1);

	                INSERT INTO grupa (id_wykl, id_stud, id_przed) VALUES (2,1,2);
	                INSERT INTO grupa (id_wykl, id_stud, id_przed) VALUES (2,2,2);

	                INSERT INTO grupa (id_wykl, id_stud, id_przed) VALUES (3,1,3);
	                INSERT INTO grupa (id_wykl, id_stud, id_przed) VALUES (3,3,3);
                ";
                command = new SqlCommand(insertCommand, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("Dodano potrzebne dane!\n");


                // ZADANIE 3C
                string wykladowca_command = @"
                SELECT w.fname, w.lname, COUNT(s.id) AS students_count FROM grupa g
	                JOIN student s ON s.id = g.id_stud
	                JOIN wykladowca w ON w.id = g.id_wykl
	                GROUP BY w.fname, w.lname
                ";

                Console.WriteLine("Liczba studentow dla kazdego wykladowcy:\n");

                command = new SqlCommand(wykladowca_command, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}",
                    datareader["fname"].ToString(),
                    datareader["lname"].ToString(),
                    datareader["students_count"].ToString());
                }
                datareader.Close();
                Console.WriteLine("\n");

                string kurs_command = @"
                SELECT p.name, COUNT(s.id) AS students_count FROM grupa g
	                JOIN student s ON s.id = g.id_stud
	                JOIN przedmiot p ON p.id = g.id_przed
	                GROUP BY p.name
                ";

                Console.WriteLine("Liczba studentow dla kazdego kursu:\n");

                command = new SqlCommand(kurs_command, connection);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t",
                    datareader["name"].ToString(),
                    datareader["students_count"].ToString());
                }
                Console.WriteLine("\n");
            }
            catch (SqlException ex)
            { Console.WriteLine(ex.Message); }
            finally
            { connection.Close(); }
            Console.Write("Press a Key to Continue...");
            Console.ReadKey();
        }
    }
}