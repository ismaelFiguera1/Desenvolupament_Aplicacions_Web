namespace Cistell_de_la_compra.Models
{
    public class ProducteComprat
    {
        public int Id { get; set; }

        public Producte Producte { get; set; }

        public string Nom{ get; set; }

        public double Preu {  get; set; }

        public int quantitat { get; set; }
    }
}
