
/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Animals;
namespace Solution_Assignment_4.Reptiles;


/// <summary>
/// Reptile class
/// </summary>
public abstract class Reptile : Animal
{
    /// <summary>
    /// Private attribute
    /// </summary>
    private bool isDeadly;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="gender">Gender</param>
    /// <param name="category">Category</param>
    /// <param name="type">Type</param>
    /// <param name="isDeadly">Is deadly</param>
    public Reptile(string name, int age, EAnimalGender gender, EAnimalCategory category, EReptile type, bool isDeadly)
        : base(name, age, gender, category, type)
    {
        IsDeadly = isDeadly;
    }

    /// <summary>
    /// Is deadly property
    /// </summary>
    public bool IsDeadly
    {
        get { return isDeadly; }
        set { isDeadly = value; }
    }

    /// <summary>
    /// Get food schedule for the reptile
    /// </summary>
    /// <returns>Food schedule</returns>
    public abstract override FoodSchedule GetFoodSchedule();

    /// <summary>
    /// Get extra reptile information
    /// </summary>
    /// <returns>Extra reptile information</returns>
    public override string GetExtraInfo()
    {
        string animalBase = base.GetExtraInfo();
        return $"{animalBase} Is deadly: {IsDeadly}";
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Reptile attributes in string</returns>
    public override string ToString()
    {
        string animalBase = base.ToString();
        return $"{animalBase} IsDeadly: {IsDeadly}";
    }
}