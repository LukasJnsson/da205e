
/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Animals;
namespace Solution_Assignment_4.Mammals;


/// <summary>
/// Monkey class
/// </summary>
public class Monkey : Mammal
{
    /// <summary>
    /// Private attributes
    /// </summary>
    private string color;
    private FoodSchedule foodSchedule;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="gender">Gender</param>
    /// <param name="category">Category</param>
    /// <param name="type">Type</param>
    /// <param name="numberOfTeeth">Number of teeth</param>
    /// <param name="color">Color</param>
    public Monkey(string name, int age, EAnimalGender gender, EAnimalCategory category, EMammal type, int numberOfTeeth, string color)
        : base(name, age, gender, category, type, numberOfTeeth)
    {
        Color = color;
        SetFoodSchedule();
    }

    /// <summary>
    /// Color property
    /// </summary>
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    /// <summary>
    /// Set food schedule
    /// </summary>
    private void SetFoodSchedule()
    {
        foodSchedule = new FoodSchedule();
        foodSchedule.EaterType = EEaterType.Herbivore;
        foodSchedule.Add("Fruit Sandwich and Banana");
        foodSchedule.Add("Seeds");
        foodSchedule.Add("Banana Buffet");
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
    /// Get extra monkey information
    /// </summary>
    /// <returns>Extra monkey information</returns>
    public override string GetExtraInfo()
    {
        string mammalBase = base.GetExtraInfo();
        return $"{mammalBase} Color: {Color}";
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Monkey attributes in string</returns>
    public override string ToString()
    {
        string mammalBase = base.ToString();
        return $"{mammalBase} Color: {Color}";
    }
}