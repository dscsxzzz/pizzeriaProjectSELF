namespace COLORADO.Data.Models;

public class Pizza
{
    public int id { get; set; }
    public string name { get; set; } = "Unnamed";
    public bool veg { get; set; } = false;
    public int price { get; set; } = 10;
    public string description { get; set; } = "Undescribed";
    public string img { get; set; } = "none";
    public int mediumPan { get; set; } = 5;
    public int mediumstuffedcrustcheesemax { get; set; } = 5;
    public int mediumstuffedcrustvegkebab { get; set; } = 5;
}