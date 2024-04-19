
/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Animals;
namespace Solution_Assignment_4.Mammals;


/// <summary>
/// Dog class
/// </summary>
public class Dog : Mammal
{
    /// <summary>
    /// Private attributes
    /// </summary>
    private string breed;
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
    /// <param name="breed">Breed</param>
    public Dog(string name, int age, EAnimalGender gender, EAnimalCategory category, EMammal type, int numberOfTeeth, string breed)
        : base(name, age, gender, category, type, numberOfTeeth)
    {
        Breed = breed;
        SetFoodSchedule();
    }

    /// <summary>
    /// Breed property
    /// </summary>
    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    /// <summary>
    /// Set food schedule
    /// </summary>
    private void SetFoodSchedule()
    {
        foodSchedule = new FoodSchedule();
        foodSchedule.EaterType = EEaterType.Carnivore;
        foodSchedule.Add("Peanut butter and jelly sandwich");
        foodSchedule.Add("Meatballs");
        foodSchedule.Add("Lasagna");
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
    /// Get extra dog information
    /// </summary>
    /// <returns>Extra dog information</returns>
    public override string GetExtraInfo()
    {
        string mammalBase = base.GetExtraInfo();
        return $"{mammalBase} Breed: {Breed}";
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Dog attributes in string</returns>
    public override string ToString()
    {
        string mammalBase = base.ToString();
        return $"{mammalBase} Breed: {Breed}";
    }
}