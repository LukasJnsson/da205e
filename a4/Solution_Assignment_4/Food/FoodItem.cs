
/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Manager;
namespace Solution_Assignment_4.Food;


/// <summary>
/// FoodItem class
/// </summary>
public class FoodItem
{
    /// <summary>
    /// Private attributes
    /// </summary>
    private string id;
    private string name;
    private ListManager<string> ingredients;

    /// <summary>
    /// FoodItem constructor
    /// </summary>
	public FoodItem()
    {
        ingredients = new ListManager<string>();
    }

    /// <summary>
    /// Id property
    /// </summary>
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    /// <summary>
    /// Name property
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    /// <summary>
    /// Ingredients property
    /// </summary>
    public ListManager<string> Ingredients
    {
        get { return ingredients; }
    }


    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Food item attributes in string</returns>
    public override string ToString()
    {
        string ingredients = string.Join(", ", Ingredients.GetList());
        return $"Id: {Id} Name: {Name} Ingredients: {ingredients}";
    }
}