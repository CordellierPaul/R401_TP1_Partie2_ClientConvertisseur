﻿namespace ClientConvertisseurV2.Models
{
    public class Devise
    {
        public int Id { get; set; }
        public string NomDevise { get; set; }
        public double Taux { get; set; }

        public Devise() { }

        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }
    }
}
