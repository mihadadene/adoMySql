using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            //connexion vers la BD north
            //chaine de connection
            string cs = "server = localhost;user = root; " + "database = northwindmysql; port = 3306";

            //objet de connexion

            MySqlConnection connection = new MySqlConnection(cs);
            try
            {
                Console.WriteLine("Connection sur MySql....");
                connection.Open();

                //cree une requet
                string query = "select ContactName, CompanyName from customers";

                //preparer l'excution de la requet
                MySqlCommand sql = new MySqlCommand(query, connection);

                //Récuperer le curseur
                MySqlDataReader reader = sql.ExecuteReader();

                //parcourir le curseur
                while (reader.Read())
                {
                    string nom, company;
                    nom = (string)reader[0];
                    company = (string)reader[1];
                    Console.WriteLine("nom: {0} - compangnie: {1}", nom, company);
                    //Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Clone();
            }
            }
        }
    }

