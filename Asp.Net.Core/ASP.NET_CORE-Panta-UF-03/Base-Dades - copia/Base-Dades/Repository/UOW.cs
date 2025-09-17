using Base_Dades.Data;
using Base_Dades.Repository.Interfaces;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;
namespace Base_Dades.Repository
{
    public class UOW
    {
        MySqlConnection? conn;
        MySqlTransaction trans;
        public void Open()
        {
            conn = DB.ObtenirConnexio();
            conn.Open();
            if (conn == null) throw new Exception("BD kaput");
            trans = conn.BeginTransaction();

        }

        public void commit ()
        {
            trans.Commit();
        }

        public void Rollback()
        {
            trans.Rollback();
        }

        ICityRepository ciutats = new CityRepository(conn, trans);
        ICountryRepository paisos = new CountryRepository();
        public void Close()
        {
            conn.Close();

        }

        
    }
}
