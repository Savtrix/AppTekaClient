﻿namespace AppTekaClient.Models
{
    public class Drug
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public bool NeedPrescribtion { get; set; }
    }
}