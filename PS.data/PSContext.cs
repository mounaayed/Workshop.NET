using Microsoft.EntityFrameworkCore;
using PS.data.MyConfiguration;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.data
{
    public class PSContext:DbContext
        //id wala nomclassesuivi id : bech ye5ouha id meta3 classe héthika
    {

        public DbSet<Product> Products { get; set; } //esm table le meme nom ama lezem tezid s fil le5er (regle)

        public DbSet<Biological> Biologicals { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Achat> Achats { get; set; }

        public DbSet<Client> Clients { get; set; }
        //lezem lazy loading bech accedi apparment lil classe fi west classe
        //te9olou chowa bech yelodi sinon mayjibech eli fi westou wa7dou

        //dbset : type bech gedou biha crud ...

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Par défaut, EF Core ne charge pas les données associées.
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                       Initial Catalog=ProductStoreDB;
                                       Integrated Security=true;
                                       MultipleActiveResultSets=true");  //usemysql  //ProductStoreDB esm base //par
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //par defulat yelehom fi table wa7da
             modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
           // modelBuilder.ApplyConfiguration(new ChemicalConfiguration()); min cours


            //   modelBuilder.Entity<Category>().ToTable("myCategories").HasKey(c => c.CategoryId);
            //   modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);


            //configure inheritance table per type
            modelBuilder.Entity<Chemical>().ToTable("Chemical");
            modelBuilder.Entity<Biological>().ToTable("Biological");

            //config table porteuse de donnée 
            modelBuilder.Entity<Achat>().HasKey(c => new { c.ClientFK, c.ProductFK, c.DateAchat });


            //definir configuration par rapport tous les models
            var properties = modelBuilder.Model.GetEntityTypes().
                SelectMany(e => e.GetProperties()).Where(p => p.Name.StartsWith("Name") &&
                  p.ClrType == typeof(string));
            foreach(var p in properties)
            {
                p.SetColumnName("Myname");
            }

            ////kol type string required
            //var stringproperties = modelBuilder.Model.GetEntityTypes().
            //   SelectMany(e => e.GetProperties()).Where(p =>  p.ClrType == typeof(string));
            //foreach (var p in stringproperties)
            //{
            //    p.IsNullable=false;
            //}



            base.OnModelCreating(modelBuilder);   //ki ya5le9 migration ye3ayet lil héthi
        }











        //Integrated Security : manich bech 7ot passwod w login
        //usesqlserver ,....
        //OnConfiguring bech configuri base biha 

        //migration : va faire une comparaison entre code wel bd bech generi un code ki va upgrade notre base

        //fil .net dima bidirectionnel

        //Microsoft.EntityFrameworkCore.Tools  data 
        //Microsoft.EntityFrameworkCore.desgin 3la gui

        //Add-migration   te7athereha 
        //Update-Database   tegedeha
        //wera be3athehom dima


        //remove-migration :Pour supprimer la dernière migration

        //Update-Database -Migration MyFirstMigration  : esm ay wad7a
    }
}
        