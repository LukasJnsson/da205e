
/*
Lukas Jönsson
17/04-2024
*/

namespace Solution_Assignment_6;


/// <summary>
/// Product class
/// </summary>
public class Product
{
    /// <summary>
    /// Auto-properties
    /// </summary>
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public double Tax { get; set; }

    /// <summary>
    /// Returns total tax
    /// </summary>
    public double TotalTax => Math.Round(Price * Quantity * (Tax / 100), 2);

    /// <summary>
    /// Returns total price including tax
    /// </summary>
    public double TotalPrice => Math.Round(Price * Quantity + TotalTax, 2);
}