using Cistell_de_la_compra.Data;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;

using Microsoft.EntityFrameworkCore;
using Cistell_de_la_compra.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Cistell_de_la_compra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Producte> Productes { get; set; }
        public DbSet<Usuari> Usuaris { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producte>().ToTable("Productes");
            modelBuilder.Entity<Usuari>().ToTable("Usuaris");
            modelBuilder.Entity<Producte>().HasData(
                new Producte { CodiProducte = "abc123", Nom = "Pizza", Preu=3.25 , Imatge = null , ImatgeFile = null },
                new Producte { CodiProducte = "dfg563", Nom = "Hamburguessa", Preu = 65.36, Imatge = null, ImatgeFile = null },
                new Producte { CodiProducte = "47jk5", Nom = "Arros", Preu = 89.0, Imatge = null, ImatgeFile = null }
            );
            modelBuilder.Entity<Usuari>().HasData(
                new Usuari { Email = "ifiguera@almata.cat", Nif = "djhdh56f", Nom = "Ismael", Cognom = "Figuera Farré", Telefon = "683334616", DataNaixement = new DateTime(2004,02,12) },
                new Usuari { Email = "jgallard@almata.cat", Nif = "qaqa523q", Nom = "Julia", Cognom = "Gallart Zaragoza", Telefon = "201456365", DataNaixement = new DateTime(2004, 08, 26) },
                new Usuari { Email = "fvilanova@almata.cat", Nif = "52dd523q", Nom = "Francesc", Cognom = "Vilanova Forja", Telefon = "789665666", DataNaixement = new DateTime(2004, 06, 15) }
            );
        }


        }
}

