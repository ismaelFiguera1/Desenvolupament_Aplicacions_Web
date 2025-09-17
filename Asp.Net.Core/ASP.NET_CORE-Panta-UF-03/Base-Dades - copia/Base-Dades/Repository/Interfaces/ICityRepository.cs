using Base_Dades.Models;

namespace Base_Dades.Repository.Interfaces
{
    public interface ICityRepository
    {
        Ciutat BuscarCiutat(int idCiutat);
        bool comprobatCiutatDuplicada(Ciutat city);
        void crearCiutat(Ciutat city);
        void DeleteCiutat(int idCiutat);
        List<Ciutat> ObtenirCiutats();
        void Update(Ciutat city);
    }
}