using Base_Dades.Data;
using Base_Dades.Models;
using Base_Dades.Repository.Interfaces;
using Base_Dades.ViewModels;
using MySql.Data.MySqlClient;

namespace Base_Dades.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public List<Pais> obtenirPaisos()
        {
            var llista = new List<Pais>();

            string comanda = "select * from country";

            var conn = DB.ObtenirConnexio();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = comanda;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var pais = new Pais();
                pais.Code = reader.GetString("Code");
                pais.Name = reader.GetString("Name");
                pais.Continent = reader.GetString("Continent");
                pais.Region = reader.GetString("Region");
                pais.SurfaceArea = reader.GetDouble("SurfaceArea");
                if (reader.IsDBNull(reader.GetOrdinal("IndepYear")))
                {
                    pais.IndepYear = null;
                }
                else
                {
                    pais.IndepYear = reader.GetInt32("IndepYear");
                }

                pais.Population = reader.GetInt32("Population");

                if (reader.IsDBNull(reader.GetOrdinal("LifeExpectancy")))
                {
                    pais.Lifeexpectancy = null;
                }
                else
                {
                    pais.Lifeexpectancy = reader.GetDouble("LifeExpectancy");
                }

                pais.Gnp = reader.GetDouble("GNP");

                if (reader.IsDBNull(reader.GetOrdinal("GNPOld")))
                {
                    pais.GnpOld = null;
                }
                else
                {
                    pais.GnpOld = reader.GetDouble("GNPOld");
                }

                pais.Localname = reader.GetString("LocalName");
                pais.GovernmentForm = reader.GetString("GovernmentForm");

                if (reader.IsDBNull(reader.GetOrdinal("HeadOfState")))
                {
                    pais.HeadofState = null;
                }
                else
                {
                    pais.HeadofState = reader.GetString("HeadOfState");
                }

                

                if (reader.IsDBNull(reader.GetOrdinal("Capital")))
                {
                    pais.Capital = null;
                }
                else
                {
                    pais.Capital = reader.GetInt32("Capital");
                }


                pais.Code2 = reader.GetString("Code2");

                llista.Add(pais);
            }
            conn.Close();




            return llista;
        }

        public PaisosCiutats paisCiutat(Ciutat city)
        {
            var paisCiutat = new PaisosCiutats();
            var pais = new Pais();
            

            string comanda = "SELECT * FROM country INNER JOIN city on country.Code = city.CountryCode WHERE city.ID = @codi";

            var conn = DB.ObtenirConnexio();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = comanda;
            cmd.Parameters.AddWithValue("@codi", city.id);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                pais.Code = reader.GetString("Code");
                pais.Name = reader.GetString("Name");
                pais.Continent = reader.GetString("Continent");
                pais.Region = reader.GetString("Region");
                pais.SurfaceArea = reader.GetDouble("SurfaceArea");
                if (reader.IsDBNull(reader.GetOrdinal("IndepYear")))
                {
                    pais.IndepYear = null;
                }
                else
                {
                    pais.IndepYear = reader.GetInt32("IndepYear");
                }

                pais.Population = reader.GetInt32("Population");

                if (reader.IsDBNull(reader.GetOrdinal("LifeExpectancy")))
                {
                    pais.Lifeexpectancy = null;
                }
                else
                {
                    pais.Lifeexpectancy = reader.GetDouble("LifeExpectancy");
                }

                pais.Gnp = reader.GetDouble("GNP");

                if (reader.IsDBNull(reader.GetOrdinal("GNPOld")))
                {
                    pais.GnpOld = null;
                }
                else
                {
                    pais.GnpOld = reader.GetDouble("GNPOld");
                }

                pais.Localname = reader.GetString("LocalName");
                pais.GovernmentForm = reader.GetString("GovernmentForm");
                pais.HeadofState = reader.GetString("HeadOfState");

                if (reader.IsDBNull(reader.GetOrdinal("Capital")))
                {
                    pais.Capital = null;
                }
                else
                {
                    pais.Capital = reader.GetInt32("Capital");
                }


                pais.Code2 = reader.GetString("Code2");
            }

            paisCiutat.pais = pais;


            return paisCiutat;
        }
    }


}
