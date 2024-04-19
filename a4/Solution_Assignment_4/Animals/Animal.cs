
/* 
Lukas Jönsson
29/3-2024
*/

namespace Solution_Assignment_4.Animals;


/// <summary>
/// Animal class
/// </summary>
[Serializable]
public class Animal : IAnimal
{
    /// <summary>
    /// Private attributes
    /// </summary>
    private string id;
    private string name;
    private int age;
    private EAnimalGender gender;
    private EAnimalCategory category;
    private Enum type;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="age">Age</param>
    /// <param name="gender">Gender</param>
    /// <param name="category">Category</param>
    /// <param name="type">Type</param>
    public Animal(string name, int age, EAnimalGender gender, EAnimalCategory category, Enum type)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Category = category;
        Type = type;
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
    /// Age property
    /// </summary>
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    /// <summary>
    /// Gender property
    /// </summary>
    public EAnimalGender Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    /// <summary>
    /// Category property
    /// </summary>
    public EAnimalCategory Category
    {
        get { return category; }
        set { category = value; }
    }

    /// <summary>
    /// Type property
    /// </summary>
    public Enum Type
    {
        get { return type; }
        set { type = value; }
    }

    /// <summary>
    /// Food schedule for the animal
    /// </summary>
    /// <returns>Food schedule</returns>
    public virtual FoodSchedule GetFoodSchedule()
    {
        return new FoodSchedule();
    }

    /// <summary>
    /// Get extra animal information
    /// </summary>
    /// <returns>Extra animal information</returns>
    public virtual string GetExtraInfo()
    {
        return string.Format($"Category: {category}");
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Animal attributes in string</returns>
    public override string ToString()
    {
        return $"Id: {Id} Name: {Name} Age: {Age} Gender: {Gender} Category: {Category} Type: {Type}";
    }
}