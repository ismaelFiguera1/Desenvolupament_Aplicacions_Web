using System.Diagnostics;

namespace API_Cronometre.Services
{
    public class CronometreService
    {
        public List<Cronometre> cronometres = new();
        public Dictionary<Guid, Stopwatch> valorsCronometres = new Dictionary<Guid, Stopwatch>();

        public CronometreService()
        {

            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            Guid id3 = Guid.NewGuid();


            cronometres.Add(new Cronometre(id1, false, "Temporitzador1", 0.0));
            cronometres.Add(new Cronometre(id2, false, "Temporitzador2", 0.0));
            cronometres.Add(new Cronometre(id3, false, "Temporitzador3", 0.0));

            Stopwatch relotge = new Stopwatch();
            Stopwatch relotge1 = new Stopwatch();
            Stopwatch relotge2 = new Stopwatch();


            valorsCronometres.Add(cronometres[0].Id, relotge);
            valorsCronometres.Add(cronometres[1].Id, relotge1);
            valorsCronometres.Add(cronometres[2].Id, relotge2);

        }





        // Obtenim TOTS els conometres





        public List<Cronometre> ObtenirCronometres()
        {
            return cronometres;
        }





        // Iniciem el conometre que tingu el id





        public bool IniciarCronometre(Guid id)
        {
            bool trobat = false;
            
            foreach (Cronometre c in cronometres)
            {
                // Busco el id a la llista de cronometres 
                if (c.Id == id)
                {
                    trobat = true;
                    // Si el trobo, a les KEY del diccionari busco el id
                    if (valorsCronometres.ContainsKey(id))
                    {
                        // Creo el Stopwatch, que es el que fa la gestio del temps
                        Stopwatch reloj = valorsCronometres[id];

                        // Si el relotge no esta corrent l'inicio
                        if (!reloj.IsRunning)
                        {
                            reloj.Start();           
                            c.Executant = true;      
                        }
                    }

                    break; 
                } 
            }
            return trobat;
        }





        // Vejem l'estat del conometre buscat per id





        public Cronometre? EstatCronometre(Guid id)
        {

            // Busquem el conometre
            foreach (Cronometre c in cronometres)
            {
                if (c.Id == id)
                {
                    // Comprovem si hi ha un rellotge al diccionari
                    if (valorsCronometres.ContainsKey(id))
                    {
                        Stopwatch rellotge = valorsCronometres[id];

                        // Si el rellotge està funcionant, actualitzem el temps actual
                        if (rellotge.IsRunning)
                        {
                            c.TempsTranscorregut = rellotge.Elapsed.TotalSeconds;
                        }
                    }

                    return c; // Retornem el cronòmetre amb el seu estat actualitzat
                }
            }

            return null; // Si no s’ha trobat cap cronòmetre amb aquest ID
        }





        // Pausem el cronometre que tingui el id





        public double? PausarCronometre(Guid id)
        {
            foreach (Cronometre c in cronometres)
            {
                if (c.Id == id)
                {
                    if (!valorsCronometres.ContainsKey(id))
                    {
                        return null; 
                    }

                    Stopwatch rellotge = valorsCronometres[id];

                    if (!rellotge.IsRunning)
                    {
                        return null; 
                    }

                    rellotge.Stop();

                    double segons = rellotge.Elapsed.TotalSeconds;

                    c.TempsTranscorregut = segons; 

                    c.Executant = false;



                    return segons;
                }
            }

            return null;
        }





        // Comprobem l'estat per id





        public string? ObtenirEstat(Guid id)
        {
            foreach (Cronometre c in cronometres)
            {
                if (c.Id == id)
                {
                    if (c.Executant)
                    {
                        return "Started";
                    }
                    else
                    {
                        return "Paused";
                    }
                }
            }
            return null;
        }





        // Resume





        public double? Resume(Guid id)
        {
            foreach (Cronometre c in cronometres)
            {
                if (c.Id == id)
                {
                    if (!valorsCronometres.ContainsKey(id)) return null;

                    Stopwatch rellotge = valorsCronometres[id];

                    if (rellotge.IsRunning) return null;

                    rellotge.Start();

                    c.Executant = true;

                    return rellotge.Elapsed.TotalSeconds;
                }
            }

            return null;
        }





        // Parar i esborrar per id





        public double? STOPCronometre(Guid id)
        {
            foreach (Cronometre c in cronometres)
            {
                if (c.Id == id)
                {
                    if (!valorsCronometres.ContainsKey(id)) return null; 

                    Stopwatch rellotge = valorsCronometres[id];

                    if (rellotge.IsRunning)
                    {
                        rellotge.Stop();
                    }

                    double segons = rellotge.Elapsed.TotalSeconds;

                    valorsCronometres.Remove(id);

                    cronometres.Remove(c);

                    return segons;
                }
            }

            return null;
        }





        // Crear i iniciar unconometre i retornar el id





        public Guid CrearINiciarCronometre()
        {
            Guid nouId = Guid.NewGuid();

            string nom = $"Cronometre {cronometres.Count + 1}";

            Cronometre nou = new Cronometre(nouId, true, nom, 0.0);

            cronometres.Add(nou);

            Stopwatch rellotge = new Stopwatch();
            rellotge.Start();

            valorsCronometres.Add(nouId, rellotge);

            return nouId;
        }

    }
}



