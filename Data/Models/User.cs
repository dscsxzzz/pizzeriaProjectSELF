﻿namespace COLORADO.Data.Models
{
    public class User
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string name { get; set; } = "";
        public string phone { get; set; } = "";
        public string surname { get; set; } = "";
        public string address { get; set; } = "";
    }
}
