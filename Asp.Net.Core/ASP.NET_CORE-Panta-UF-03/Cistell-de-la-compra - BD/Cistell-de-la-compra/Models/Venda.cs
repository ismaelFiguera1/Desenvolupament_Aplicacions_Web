namespace Cistell_de_la_compra.Models
{
    public class Venda
    {
        public int NumFactura { get; set; }

        public Usuari Comprador { get; set; }

        public string Nif { get; set; }

        public string Nom {  get; set; }

        public string Cognom { get; set; }

        public DateTime Data {  get; set; }

        public List<ProducteComprat> LlistaProductesComprats { get; set; }
    }
}
