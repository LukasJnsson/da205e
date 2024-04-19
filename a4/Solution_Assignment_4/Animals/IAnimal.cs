
/* 
Lukas Jönsson
29/3-2024
*/

namespace Solution_Assignment_4.Animals;


/// <summary>
/// Animal interface
/// </summary>
public interface IAnimal
{
    string Id { get; set; }
    string Name { get; set; }
    int Age { get; set; }
    EAnimalGender Gender { get; set; }
    EAnimalCategory Category { get; set; }
    Enum Type { get; set; }
    FoodSchedule GetFoodSchedule();
    string GetExtraInfo();
}