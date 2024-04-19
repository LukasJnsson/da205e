
/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Manager;
namespace Solution_Assignment_4.Animals;


/// <summary>
/// Animal manager class
/// </summary>
public class AnimalManager : ListManager<Animal>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public AnimalManager()
    {
    }

    /// <summary>
    /// Add animal
    /// </summary>
    /// <param name="animal">Animal object</param>
    /// <returns>True in case the object is added, otherwise false</returns>
    public bool AddAnimal(Animal animal)
    {
        bool isAdded = false;

        if (animal != null)
        {
            switch (animal.Category)
            {
                case EAnimalCategory.Mammal:
                    animal.Id = $"M{Count + 1}";
                    break;

                case EAnimalCategory.Reptile:
                    animal.Id = $"R{Count + 1}";
                    break;
            }
            Add(animal);
            isAdded = true;
        }
        return isAdded;
    }

    /// <summary>
    /// Change animal
    /// (Implemented in case the category changes and therefore requieres an id
    /// with the other category)
    /// </summary>
    /// <param name="animal">Animal object</param>
    /// <returns>True in case the object is changed, otherwise false</returns>
    public bool ChangeAnimal(int index, Animal animal)
    {
        bool isChanged = false;

        if (animal != null)
        {
            switch (animal.Category)
            {
                case EAnimalCategory.Mammal:
                    animal.Id = $"M{Count + 1}";
                    break;

                case EAnimalCategory.Reptile:
                    animal.Id = $"R{Count + 1}";
                    break;
            }
            Change(index, animal);
            isChanged = true;
        }
        return isChanged;
    }
}