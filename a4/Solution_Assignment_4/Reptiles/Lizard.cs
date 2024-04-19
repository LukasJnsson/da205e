
/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Animals;
namespace Solution_Assignment_4.Reptiles;


/// <summary>
/// Lizard class
/// </summary>
public class Lizard : Reptile
{
    /// <summary>
    /// Private attributes
    /// </summary>
    private int tailLength;
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
    /// <param name="tailLength">Tail length</param>
    public Lizard(string name, int age, EAnimalGender gender, EAnimalCategory category, EReptile type, bool isDeadly, int tailLength)
        : base(name, age, gender, category, type, isDeadly)
    {
        TailLength = tailLength;
        SetFoodSchedule();
    }

    /// <summary>
    /// Tail length property
    /// </summary>
    public int TailLength
    {
        get { return tailLength; }
        set { tailLength = value; }
    }

    /// <summary>
    /// Set food schedule
    /// </summary>
    private void SetFoodSchedule()
    {
        foodSchedule = new FoodSchedule();
        foodSchedule.EaterType = EEaterType.Omnivorous;
        foodSchedule.Add("Chopped Fruits");
        foodSchedule.Add("Lasagna");
        foodSchedule.Add("Pear Pie");
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
    /// Get extra lizard information
    /// </summary>
    /// <returns>Extra lizard information</returns>
    public override string GetExtraInfo()
    {
        string reptileBase = base.GetExtraInfo();
        return $"{reptileBase} Tail length: {tailLength}";
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Lizard attributes in string</returns>
    public override string ToString()
    {
        string reptileBase = base.ToString();
        return $"{reptileBase} TailLength: {TailLength}";
    }
}