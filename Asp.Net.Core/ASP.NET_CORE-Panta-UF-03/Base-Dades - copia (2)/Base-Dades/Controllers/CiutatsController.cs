using Base_Dades.Models;
using Base_Dades.Repository.Interfaces;
using Base_Dades.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class CiutatsController : Controller
    {
        private ICityRepository _cityRepository;
        private ICountryRepository _countryRepository;

        public CiutatsController(ICityRepository pr, ICountryRepository ar)
        {
            this._cityRepository = pr;
            this._countryRepository = ar;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dades = new PaisosCiutats();
            dades.llistaCiutats = _cityRepository.ObtenirCiutats();
            return View(dades);
        }

        [HttpPost]
        public IActionResult AltaCiutat(PaisosCiutats dades)
        {
            if (!ModelState.IsValid)
            {
                
                dades.llistaPaisos = _countryRepository.obtenirPaisos();
                return View("Afegir",dades);
            }

            _cityRepository.crearCiutat(dades.ciutat);
            TempData["Missatge"] = "La ciutat s'ha creat correctament";
            dades.llistaCiutats = _cityRepository.ObtenirCiutats();

            return View("Index", dades);
        }

        public IActionResult DeleteCiutat(int idCiutatBuscar)
        {
            var dades = new PaisosCiutats();
            _cityRepository.DeleteCiutat(idCiutatBuscar);
            var llistaCiutats = _cityRepository.ObtenirCiutats();
            TempData["Missatge"] = "La ciutat amb id " + idCiutatBuscar + " s'ha eliminat correctament";
            dades.llistaCiutats = llistaCiutats;
            return View("Index", dades);
        }

        public IActionResult UpdateCiutat(int idCiutatBuscar)
        {
                var ciutat = _cityRepository.BuscarCiutat(idCiutatBuscar);
                var paisos = _countryRepository.obtenirPaisos();

            var dades = _countryRepository.paisCiutat(ciutat);
            dades.ciutat = ciutat;
            dades.llistaPaisos = paisos;
                return View("Editar", dades);
        }


        public IActionResult UpdateCiutatFINAL(Ciutat ciutat)
        {
            _cityRepository.Update(ciutat);

            var dades = _countryRepository.paisCiutat(ciutat);

            dades.ciutat = ciutat;

            dades.llistaPaisos = _countryRepository.obtenirPaisos();

            TempData["Missatge"] = "La ciutat s'ha actualitzat correctament";

            return View("Editar", dades);
        }

        [HttpGet]
        public IActionResult Afegir()
        {
            var dades = new PaisosCiutats();
            dades.ciutat = new Ciutat();
            dades.llistaPaisos = _countryRepository.obtenirPaisos();
            return View(dades);
        }
    }
}
