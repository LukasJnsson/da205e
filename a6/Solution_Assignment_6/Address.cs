
/*
Lukas Jönsson
17/04-2024
*/

namespace Solution_Assignment_6;


/// <summary>
/// Address record
/// </summary>
/// <param name="Street">Street</param>
/// <param name="Zipcode">Zip code</param>
/// <param name="City">City</param>
/// <param name="Country">Country</param>
public record Address(string Street, string Zipcode, string City, string Country);