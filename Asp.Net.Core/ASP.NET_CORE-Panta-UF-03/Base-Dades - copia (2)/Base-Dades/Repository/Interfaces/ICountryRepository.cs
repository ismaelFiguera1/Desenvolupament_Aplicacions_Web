using Base_Dades.Models;
using Base_Dades.ViewModels;

namespace Base_Dades.Repository.Interfaces
{
    public interface ICountryRepository
    {
        List<Pais> obtenirPaisos();
        PaisosCiutats paisCiutat(Ciutat city);
    }
}