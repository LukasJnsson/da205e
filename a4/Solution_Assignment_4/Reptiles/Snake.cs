
/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Animals;
namespace Solution_Assignment_4.Reptiles;


/// <summary>
/// Snake class
/// </summary>
public class Snake : Reptile
{
    /// <summary>
    /// Private attributes
    /// </summary>
    private int length;
    private FoodSchedule foodSchedule;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="gender">Gender</param>
    /// <param name="category">Category</param>
    /// <param name="type">Type</param>
    /// <param name="isDeadly">Is deadly</param>
    /// <param name="length">Length</param>
    public Snake(string name, int age, EAnimalGender gender, EAnimalCategory category, EReptile type, bool isDeadly, int length)
        : base(name, age, gender, category, type, isDeadly)
    {
        Length = length;
        SetFoodSchedule();
    }

    /// <summary>
    /// Length property
    /// </summary>
    public int Length
    {
        get { return length; }
        set { length = value; }
    }

    /// <summary>
    /// Set food schedule
    /// </summary>
    private void SetFoodSchedule()
    {
        foodSchedule = new FoodSchedule();
        foodSchedule.EaterType = EEaterType.Carnivore;
        foodSchedule.Add("Bird Buffet");
        foodSchedule.Add("T-bone Steak");
        foodSchedule.Add("Apple Pie");
    }

    /// <summary>
    /// Get food schedule
    /// </summary>
    /// <returns></returns>
    public override FoodSchedule GetFoodSchedule()
    {
        return foodSchedule;
    }

    /// <summary>
    /// Get extra snake information
    /// </summary>
    /// <returns>Extra snake information</returns>
    public override string GetExtraInfo()
    {
        string reptileBase = base.GetExtraInfo();
        return $"{reptileBase} Length: {Length}";
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Snake attributes in string</returns>
    public override string ToString()
    {
        string reptileBase = base.ToString();
        return $"{reptileBase} Length: {Length}";
    }
}