﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirst_Entegrasyonu.Models.Managers
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }

        public DatabaseContext() : base("name=DataContext") // base("name=DataContext") eklendi bunu eklememizde ki amaç database e nereden bağlanacağımızı göstermektir.
        {
            Database.SetInitializer(new VeritabaniOlusturucu());
        }
    }





    public class VeritabaniOlusturucu:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Kişiler Insert ediliyor
            for (int i = 0; i < 10; i++)
            {
                Kisiler kisi = new Kisiler();
                kisi.Ad = FakeData.NameData.GetFirstName();
                kisi.Soyad = FakeData.NameData.GetSurname();
                kisi.Yas = FakeData.NumberData.GetNumber(10, 90);
                context.Kisiler.Add(kisi);
            }
            context.SaveChanges();
            //Adresler Insert ediliyor
            List<Kisiler> tumKisiler = context.Kisiler.ToList();
            foreach (Kisiler kisi in tumKisiler)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Adresler adres = new Adresler();
                    adres.AdresTanim = FakeData.PlaceData.GetAddress();
                    adres.Kisi = kisi;
                    context.Adresler.Add(adres);
                }
            }
            context.SaveChanges();
        }
    }

}