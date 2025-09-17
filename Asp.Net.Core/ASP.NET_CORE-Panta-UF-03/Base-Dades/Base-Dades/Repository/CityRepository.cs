using Base_Dades.Models;
using MySql.Data.MySqlClient;
using Base_Dades.Data;
using Base_Dades.Repository.Interfaces;
using Mysqlx.Crud;
using System.Data;

namespace Base_Dades.Repository
{
    public class CityRepository : ICityRepository
    {


        public List<Ciutat> ObtenirCiutats()
        {
            var llista = new List<Ciutat>();
            string comanda = "select * from city";

            var conn = DB.ObtenirConnexio();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = comanda;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ciutat = new Ciutat();
                ciutat.id = reader.GetInt32("ID");
                ciutat.name = reader.GetString("Name");
                ciutat.countrycode = reader.GetString("CountryCode");
                ciutat.district = reader.GetString("District");
                ciutat.population = reader.GetInt32("Population");
                llista.Add(ciutat);
            }
            conn.Close();

            return llista;
        }

        public Ciutat BuscarCiutat(int idCiutat)
        {
            Ciutat ciutat = new Ciutat();

            string comanda = "SELECT * FROM `city` WHERE id = @idCity";

            var conn = DB.ObtenirConnexio();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@idCity", idCiutat);
            cmd.CommandText = comanda;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ciutat.id = reader.GetInt32("ID");
                ciutat.name = reader.GetString("Name");
                ciutat.countrycode = reader.GetString("CountryCode");
                ciutat.district = reader.GetString("District");
                ciutat.population = reader.GetInt32("Population");
            }
            conn.Close();


            return ciutat;
        }

        public void Update(Ciutat city)
        {
            string comanda = "UPDATE city SET Name=@nom,CountryCode=@code,District=@districte,Population=@poblacio WHERE ID = @idcity";
            var conn = DB.ObtenirConnexio();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@nom", city.name);
            cmd.Parameters.AddWithValue("@code", city.countrycode);
            cmd.Parameters.AddWithValue("@districte", city.district);
            cmd.Parameters.AddWithValue("@poblacio", city.population);
            cmd.Parameters.AddWithValue("@idcity", city.id);
            cmd.CommandText = comanda;
            cmd.ExecuteNonQuery();


            conn.Close();
        }

        public void DeleteCiutat(int idCiutat)
        {



            string comanda = "DELETE FROM city WHERE ID = @idCity";
            var conn = DB.ObtenirConnexio();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.Parameters.AddWithValue("@idCity", idCiutat);
            cmd.CommandText = comanda;
            cmd.ExecuteNonQuery();


            conn.Close();


        }

        public void crearCiutat(Ciutat city)
        {
            string comanda = "INSERT INTO city(Name, CountryCode, District, Population) VALUES (@nom,@codi,@district,@poblation)";

            bool ciutatDuplicada = comprobatCiutatDuplicada(city);

            if (ciutatDuplicada)
            {
                throw new Exception("No pots entrar la mateixa ciutat 2 vegades en el mateix pais");
            }
            else
            {
                var conn = DB.ObtenirConnexio();
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = comanda;
                cmd.Parameters.AddWithValue("@nom", city.name);
                cmd.Parameters.AddWithValue("@codi", city.countrycode);
                cmd.Parameters.AddWithValue("@district", city.district);
                cmd.Parameters.AddWithValue("@poblation", city.population);
                cmd.ExecuteNonQuery();
                conn.Close();
            }




        }

        public bool comprobatCiutatDuplicada(Ciutat city)
        {
            string comanda = "SELECT count(*) FROM world.city where Name like @nomCiutat and CountryCode like @codiPais";
            var conn = DB.ObtenirConnexio();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = comanda;
            cmd.Parameters.AddWithValue("@nomCiutat", city.name);
            cmd.Parameters.AddWithValue("@codiPais", city.countrycode);
            Object contador = (long)cmd.ExecuteScalar();
            var res = Convert.ToInt64(contador);

            conn.Close();
            if (res>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
