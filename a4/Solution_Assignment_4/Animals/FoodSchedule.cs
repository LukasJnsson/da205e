
/* 
Lukas Jönsson
29/3-2024
*/

namespace Solution_Assignment_4.Animals;


/// <summary>
/// FoodSchedule class
/// </summary>
public class FoodSchedule
{
    /// <summary>
    /// Private attributes
    /// </summary>
    private EEaterType eaterType;
    private List<string> foodList;

    /// <summary>
    /// Constructor
    /// </summary>
    public FoodSchedule()
    {
        foodList = new List<string>();
    }

    /// <summary>
    /// Eater type property
    /// </summary>
    public EEaterType EaterType
    {
        get { return eaterType; }
        set { eaterType = value; }
    }

    /// <summary>
    /// Add meal
    /// </summary>
    /// <param name="meal">Meal</param>
    public void Add(string meal)
    {
        foodList.Add(meal);
    }

    /// <summary>
    /// Meals from list to array
    /// </summary>
    /// <returns>Meals in array</returns>
    public string[] GetMealList()
    {
        return foodList.ToArray();
    }
}