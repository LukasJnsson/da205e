
/*
Lukas Jönsson
17/04-2024
*/

namespace Solution_Assignment_6;

/// <summary>
/// Invoice class
/// </summary>
public class Invoice
{
    /// <summary>
    /// Auto-properties
    /// </summary>
    public Tuple<string, DateTime, DateTime> NumDate { get; set; }
    public string Receiver { get; set; }
    public Address ReceiverAddress { get; set; }
    public string Sender { get; set; }
    public Address SenderAddress { get; set; }
    public string SenderPhone { get; set; }
    public string SenderURL { get; set; }
    public List<Product> Products { get; set; }
    public double Discount { get; set; }
    public double Total { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public Invoice()
    {
        Products = new List<Product>();
    }

    /// <summary>
    /// Returns total price including tax
    /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator
    /// </summary>
    public double TotalPrice => Products.Sum(product => product.TotalPrice);

    /// <summary>
    /// Returns total price including tax and with the discount
    /// </summary>
    public double TotalPriceWithDiscount => TotalPrice - Discount;
}