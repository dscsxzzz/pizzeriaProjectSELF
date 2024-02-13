namespace COLORADO.Data.Models
{
    public class Dessert
    {
        public int id { get; set; }
        public int price { get; set; } = 10;
        public string name { get; set; } = "Unnamed";
        public string description { get; set; } = "undescribed";
        public string img { get; set; } = "None";
    }
}