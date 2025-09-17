namespace API_Cronometre
{
    public class Cronometre
    {
        public Guid Id { get; set; }
        public bool Executant { get; set; }
        public string Name { get; set; }

        public double TempsTranscorregut { get; set; }

        public Cronometre(Guid id, bool executant, string nom, double temps) 
        {
            this.Id = id;
            this.Executant = executant;
            this.Name = nom;
            this.TempsTranscorregut = temps;
        }

        public Cronometre() { }

        
        
    }
}
