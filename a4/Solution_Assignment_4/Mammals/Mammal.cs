
/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Animals;
namespace Solution_Assignment_4.Mammals;


/// <summary>
/// Mammal class
/// </summary>
public abstract class Mammal : Animal
{
    /// <summary>
    /// Private attribute
    /// </summary>
    private int numberOfTeeth;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="gender">Gender</param>
    /// <param name="category">Category</param>
    /// <param name="type">Type</param>
    /// <param name="numberOfTeeth">Number of teeth</param>
    public Mammal(string name, int age, EAnimalGender gender, EAnimalCategory category, EMammal type, int numberOfTeeth)
        : base(name, age, gender, category, type)
    {
        NumberOfTeeth = numberOfTeeth;
    }

    /// <summary>
    /// Number of teeth property
    /// </summary>
    public int NumberOfTeeth
    {
        get { return numberOfTeeth; }
        set { numberOfTeeth = value; }
    }

    /// <summary>
    /// Get food schedule for the mammal
    /// </summary>
    /// <returns>Food schedule</returns>
    public abstract override FoodSchedule GetFoodSchedule();

    /// <summary>
    /// Get extra mammal information
    /// </summary>
    /// <returns>Extra mammal information</returns>
    public override string GetExtraInfo()
    {
        string animalBase = base.GetExtraInfo();
        return $"{animalBase} Number of teeth: {NumberOfTeeth}";
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Mammal attributes in string</returns>
    public override string ToString()
    {
        string animalBase = base.ToString();
        return $"{animalBase} Number of Teeth: {NumberOfTeeth}";
    }
}