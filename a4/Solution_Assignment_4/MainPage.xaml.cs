

/* 
Lukas Jönsson
29/3-2024
*/

using Solution_Assignment_4.Animals;
using Solution_Assignment_4.Mammals;
using Solution_Assignment_4.Reptiles;
using Solution_Assignment_4.Food;
using CommunityToolkit.Maui.Storage;
namespace Solution_Assignment_4;


/// <summary>
/// MainPage class
/// </summary>
public partial class MainPage : ContentPage
{
    /// <summary>
    /// Private attributes
    /// Implemented the FileSaver and FilePicker based on the following sources
    /// https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/essentials/file-saver?tabs=windows
    /// https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-picker?view=net-maui-8.0&tabs=windows
    /// </summary>
    private string filePath;
    private bool isSaved;
    private AnimalManager animalManager;
    private FoodItem meal;
    private List<FoodItem> meals;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="fileSaver"></param>
    public MainPage()
    {
        InitializeComponent();
        InitializeEnumElements();
        InitializeInputElements();
        InitializeOutputElements();
        isSaved = true;
        animalManager = new AnimalManager();
        meals = new List<FoodItem>();
    }

    /// <summary>
    /// Initialize input elements
    /// </summary>
    private void InitializeInputElements()
    {
        animalNameEntry.Text = string.Empty;
        animalAgeEntry.Text = string.Empty;

        mammalPicker.ItemsSource = Enum.GetNames(typeof(EMammal));
        mammalNumberOfTeethEntry.Text = string.Empty;
        dogBreedEntry.Text = string.Empty;
        monkeyColorEntry.Text = string.Empty;

        mammalContainer.IsVisible = false;
        mammalDefaultContainer.IsVisible = false;
        mammalDogContainer.IsVisible = false;
        mammalMonkeyContainer.IsVisible = false;

        reptilePicker.ItemsSource = Enum.GetNames(typeof(EReptile));
        reptileIsDeadlyCheckbox.IsChecked = false;
        lizardTailLengthEntry.Text = string.Empty;
        snakeLengthEntry.Text = string.Empty;

        reptileContainer.IsVisible = false;
        reptileDefaultContainer.IsVisible = false;
        reptileLizardContainer.IsVisible = false;
        reptileSnakeContainer.IsVisible = false;

        animalFoodScheduleContainer.IsVisible = false;

        foodNameEntry.Text = string.Empty;
        ingredientEntry.Text = string.Empty;
        foodForm.IsVisible = false;
    }

    /// <summary>
    /// Initialize empty entries
    /// </summary>
    private void InitializeEntries()
    {
        animalNameEntry.Text = string.Empty;
        animalAgeEntry.Text = string.Empty;

        mammalNumberOfTeethEntry.Text = string.Empty;
        dogBreedEntry.Text = string.Empty;
        monkeyColorEntry.Text = string.Empty;

        reptileIsDeadlyCheckbox.IsChecked = false;
        lizardTailLengthEntry.Text = string.Empty;
        snakeLengthEntry.Text = string.Empty;
    }

    /// <summary>
    /// Initialize enums
    /// </summary>
    private void InitializeEnumElements()
    {
        animalGenderPicker.ItemsSource = Enum.GetNames(typeof(EAnimalGender));
        animalCategoryPicker.ItemsSource = Enum.GetNames(typeof(EAnimalCategory));
    }

    /// <summary>
    /// Initialize output elements
    /// </summary>
    private void InitializeOutputElements()
    {
        menuFileLabel.Text = "File";
        subMenuFileLabel.Text = "File";
        menuNewLabel.Text = "New";
        menuOpenLabel.Text = "Open";
        menuOpenAsTxtLabel.Text = "Text File";
        menuOpenAsJSONLabel.Text = "JSON";
        menuSaveLabel.Text = "Save";
        menuSaveAsLabel.Text = "Save As";
        menuSaveAsTxtLabel.Text = "Text File";
        menuSaveAsJSONLabel.Text = "JSON";
        menuExitLabel.Text = "Exit";

        animalNameLabel.Text = "Name:";
        animalAgeLabel.Text = "Age:";
        animalGenderLabel.Text = "Gender:";
        animalCategoryLabel.Text = "Category:";
        animalAddButton.Text = "Add animal";

        mammalLabel.Text = "Select Mammal";
        mammalNumberOfTeethLabel.Text = "Number of teeth:";
        dogBreedLabel.Text = "Breed:";
        monkeyColorLabel.Text = "Color:";

        reptileLabel.Text = "Select Reptile";
        reptileIsDeadlyLabel.Text = "Is deadly:";
        lizardTailLengthLabel.Text = "Tail length:";
        snakeLengthLabel.Text = "Length:";

        animalManagerListView.ItemsSource = null;

        animalChangeButton.Text = "Change";
        animalDeleteButton.Text = "Delete";
        animalMealListView.ItemsSource = null;

        foodFormButton.Text = "Food Form";

        foodNameLabel.Text = "Name of meal:";
        ingredientLabel.Text = "Ingredient";

        ingredientAddButton.Text = "Add";
        ingredientChangeButton.Text = "Change";
        ingredientDeleteButton.Text = "Delete";
        ingredientListView.ItemsSource = null;
        ingredientsLabel.Text = string.Empty;

        mealAddButton.Text = "Add";
        mealListView.ItemsSource = null;
        mealDeleteButton.Text = "Delete";
        mealCancelButton.Text = "Cancel";
        mealLabel.Text = string.Empty;
    }

    /// <summary>
    /// Initialize the default mammal elements
    /// </summary>
    private void InitializeMammalElements()
    {
        reptileContainer.IsVisible = false;
        reptileDefaultContainer.IsVisible = false;
        reptileLizardContainer.IsVisible = false;
        reptileSnakeContainer.IsVisible = false;

        mammalContainer.IsVisible = true;
        mammalPicker.SelectedItem = -1;
    }

    /// <summary>
    /// Initialize the default reptile elements
    /// </summary>
    private void InitializeReptileElements()
    {
        mammalContainer.IsVisible = false;
        mammalDefaultContainer.IsVisible = false;
        mammalDogContainer.IsVisible = false;
        mammalMonkeyContainer.IsVisible = false;

        reptileContainer.IsVisible = true;
        reptilePicker.SelectedItem = -1;
    }

    /// <summary>
    /// Handle animal category change
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleCategoryChanged(object sender, EventArgs e)
    {
        EAnimalCategory selectedCategory = (EAnimalCategory)Enum.Parse(typeof(EAnimalCategory), animalCategoryPicker.SelectedItem.ToString());
        switch (selectedCategory)
        {
            case EAnimalCategory.Mammal:
                InitializeMammalElements();
                break;

            case EAnimalCategory.Reptile:
                InitializeReptileElements();
                break;
        }
    }

    /// <summary>
    /// Display validation message
    /// </summary>
    /// <param name="title">Title</param>
    /// <param name="information">Information</param>
    private void DisplayValidationMessage(string title, string information)
    {
        DisplayAlert(title, information, "Continue");
    }

    /// <summary>
    /// Validate entry of type string
    /// </summary>
    /// <param name="entry">Entry</param>
    /// <returns>True if not null or empty, otherwise false</returns>
    private bool ValidateEntryString(Entry entry)
    {
        return !string.IsNullOrEmpty(entry.Text.Trim());
    }

    /// <summary>
    /// Validate entry of type int
    /// </summary>
    /// <param name="entry">Entry</param>
    /// <returns>True if of type int, otherwise false</returns>
    private bool ValidateEntryInt(Entry entry)
    {
        int dataType;
        return int.TryParse(entry.Text.Trim(), out dataType);
    }

    /// <summary>
    /// Validate default animal props
    /// </summary>
    /// <returns>True if required data and data types, otherwise false</returns>
    private bool ValidateDefaultAnimal()
    {
        bool isValid = true;

        Dictionary<Entry, string> entries = new Dictionary<Entry, string>
        {
            {animalNameEntry, "name" },
            {animalAgeEntry, "age" }
        };

        foreach (KeyValuePair<Entry, string> entry in entries)
        {

            if (entry.Key == animalAgeEntry)
            {
                if (!ValidateEntryInt(entry.Key))
                {
                    DisplayValidationMessage("Error", $"Please enter {entry.Value}!");
                    isValid = false;
                }
            }
            else
            {
                if (!ValidateEntryString(entry.Key))
                {
                    DisplayValidationMessage("Error", $"Please enter {entry.Value}!");
                    isValid = false;
                }
            }
        }

        Dictionary<Picker, string> pickers = new Dictionary<Picker, string>
        {
            {animalGenderPicker, "gender" },
            {animalCategoryPicker, "category" }
        };

        foreach (KeyValuePair<Picker, string> picker in pickers)
        {
            if (picker.Key.SelectedIndex == -1)
            {
                DisplayValidationMessage("Error", $"Please enter {picker.Value}!");
                isValid = false;
            }
        }
        return isValid;
    }

    /// <summary>
    /// Initialize the dog elements
    /// </summary>
    private void InitializeDogElements()
    {
        mammalMonkeyContainer.IsVisible = false;
        mammalDefaultContainer.IsVisible = true;
        mammalDogContainer.IsVisible = true;
    }

    /// <summary>
    /// Initialize the monkey elements
    /// </summary>
    private void InitializeMonkeyElements()
    {
        mammalDogContainer.IsVisible = false;
        mammalDefaultContainer.IsVisible = true;
        mammalMonkeyContainer.IsVisible = true;
    }

    /// <summary>
    /// Handle mammal type change
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleMammalChanged(object sender, EventArgs e)
    {
        if (mammalPicker.SelectedIndex != -1)
        {
            EMammal selectedMammal = (EMammal)Enum.Parse(typeof(EMammal), mammalPicker.SelectedItem.ToString());

            switch (selectedMammal)
            {
                case EMammal.Dog:
                    InitializeDogElements();
                    break;

                case EMammal.Monkey:
                    InitializeMonkeyElements();
                    break;
            }
        }
    }

    // <summary>
    /// Initialize the lizard elements
    /// </summary>
    private void InitializeLizardElements()
    {
        reptileSnakeContainer.IsVisible = false;
        reptileDefaultContainer.IsVisible = true;
        reptileLizardContainer.IsVisible = true;
    }

    /// <summary>
    /// Initialize the snake elements
    /// </summary>
    private void InitializeSnakeElements()
    {
        reptileLizardContainer.IsVisible = false;
        reptileDefaultContainer.IsVisible = true;
        reptileSnakeContainer.IsVisible = true;
    }

    /// <summary>
    /// Initialize on change
    /// </summary>
    private void InitializeOnChange()
    {
        InitializeEntries();
        InitializeOutputElements();
        animalManagerListView.ItemsSource = animalManager.GetList();
        animalManagerLabel.Text = $"Displays {animalManager.Count} of {animalManager.Count} animals!";

        if (animalManager.Count == 0)
        {
            animalFoodScheduleContainer.IsVisible = false;
            animalManagerLabel.IsVisible = false;
        }
    }

    /// <summary>
    /// Initialize on open
    /// </summary>
    private void InitializeOnOpen()
    {
        isSaved = true;
        animalManager = new AnimalManager();
        meals = new List<FoodItem>();
        InitializeOnChange();
        InitializeInputElements();
        InitializeOutputElements();
        animalManagerLabel.IsVisible = true;
        animalManagerLabel.Text = $"Displays {animalManager.Count} of {animalManager.Count} animals!";
    }

    /// <summary>
    /// Handle reptile type change
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleReptileChanged(object sender, EventArgs e)
    {
        if (reptilePicker.SelectedIndex != -1)
        {
            EReptile selectedReptile = (EReptile)Enum.Parse(typeof(EReptile), reptilePicker.SelectedItem.ToString());

            switch (selectedReptile)
            {
                case EReptile.Lizard:
                    InitializeLizardElements();
                    break;

                case EReptile.Snake:
                    InitializeSnakeElements();
                    break;
            }
        }
    }

    /// <summary>
    /// Validate mammal
    /// </summary>
    /// <returns>True if required data and data types, otherwise false</returns>
    private bool ValidateMammal()
    {
        bool isValid = true;

        if (mammalPicker.SelectedIndex == -1)
        {
            DisplayValidationMessage("Error", "Please select mammal type!");
            isValid = false;
        }

        if (!ValidateEntryInt(mammalNumberOfTeethEntry))
        {
            DisplayValidationMessage("Error", "Please enter number of teeth!");
            isValid = false;
        }

        EMammal selectedMammal = (EMammal)Enum.Parse(typeof(EMammal), mammalPicker.SelectedItem.ToString());
        switch (selectedMammal)
        {
            case EMammal.Dog:
                if (!ValidateEntryString(dogBreedEntry))
                {
                    DisplayValidationMessage("Error", "Please enter breed!");
                    isValid = false;
                }
                break;

            case EMammal.Monkey:
                if (!ValidateEntryString(monkeyColorEntry))
                {
                    DisplayValidationMessage("Error", "Please enter color!");
                    isValid = false;
                }
                break;
        }
        return isValid;
    }

    /// <summary>
    /// Validate reptile
    /// </summary>
    /// <returns>True if required data and data types, otherwise false</returns>
    private bool ValidateReptile()
    {
        bool isValid = true;

        if (reptilePicker.SelectedIndex == -1)
        {
            DisplayValidationMessage("Error", "Please select reptile type!");
            isValid = false;
        }

        EReptile selectedReptile = (EReptile)Enum.Parse(typeof(EReptile), reptilePicker.SelectedItem.ToString());
        switch (selectedReptile)
        {
            case EReptile.Lizard:
                if (!ValidateEntryInt(lizardTailLengthEntry))
                {
                    DisplayValidationMessage("Error", "Please enter tail length!");
                    isValid = false;
                }
                break;

            case EReptile.Snake:
                if (!ValidateEntryInt(snakeLengthEntry))
                {
                    DisplayValidationMessage("Error", "Please enter length!");
                    isValid = false;
                }
                break;
        }
        return isValid;
    }

    /// <summary>
    /// Validate category (mammal or reptile)
    /// </summary>
    /// <returns>True if required data and data types, otherwise false</returns>
    private bool ValidateCategory()
    {
        bool isCategoryValid = false;

        if (animalCategoryPicker.SelectedIndex != -1)
        {
            EAnimalCategory selectedCategory = (EAnimalCategory)Enum.Parse(typeof(EAnimalCategory), animalCategoryPicker.SelectedItem.ToString());
            switch (selectedCategory)
            {
                case EAnimalCategory.Mammal:
                    isCategoryValid = ValidateMammal();
                    break;

                case EAnimalCategory.Reptile:
                    isCategoryValid = ValidateReptile();
                    break;
            }
        }
        return isCategoryValid;
    }

    /// <summary>
    /// Handle add animal
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleAddAnimal(object sender, EventArgs e)
    {
        if (ValidateDefaultAnimal() && ValidateCategory())
        {
            Animal animal = null;
            string name = animalNameEntry.Text;
            int age = int.Parse(animalAgeEntry.Text);
            EAnimalGender gender = (EAnimalGender)Enum.Parse(typeof(EAnimalGender), animalGenderPicker.SelectedItem.ToString());
            EAnimalCategory category = (EAnimalCategory)Enum.Parse(typeof(EAnimalCategory), animalCategoryPicker.SelectedItem.ToString());

            switch (category)
            {
                case EAnimalCategory.Mammal:
                    EMammal mammalType = (EMammal)Enum.Parse(typeof(EMammal), mammalPicker.SelectedItem.ToString());
                    int numberOfTeeth = int.Parse(mammalNumberOfTeethEntry.Text);

                    switch (mammalType)
                    {
                        case EMammal.Dog:
                            string dogBreed = dogBreedEntry.Text;
                            animal = new Dog(name, age, gender, category, mammalType, numberOfTeeth, dogBreed);
                            ((Dog)animal).Breed = dogBreed;
                            break;

                        case EMammal.Monkey:
                            string monkeyColor = monkeyColorEntry.Text;
                            animal = new Monkey(name, age, gender, category, mammalType, numberOfTeeth, monkeyColor);
                            ((Monkey)animal).Color = monkeyColor;
                            break;
                    }
                    break;

                case EAnimalCategory.Reptile:
                    EReptile reptileType = (EReptile)Enum.Parse(typeof(EReptile), reptilePicker.SelectedItem.ToString());
                    bool isDeadly = reptileIsDeadlyCheckbox.IsChecked;

                    switch (reptileType)
                    {
                        case EReptile.Lizard:
                            int tailLength = int.Parse(lizardTailLengthEntry.Text);
                            animal = new Lizard(name, age, gender, category, reptileType, isDeadly, tailLength);
                            ((Lizard)animal).TailLength = tailLength;
                            break;

                        case EReptile.Snake:
                            int length = int.Parse(snakeLengthEntry.Text);
                            animal = new Snake(name, age, gender, category, reptileType, isDeadly, length);
                            ((Snake)animal).Length = length;
                            break;
                    }
                    break;
            }
            isSaved = false;
            animalManager.AddAnimal(animal);
            InitializeOnChange();
        }
    }

    /// <summary>
    /// Get index of selected animal
    /// </summary>
    /// <returns>Index of the selected animal</returns>
    private int GetSelectedAnimalIndex()
    {
        Animal[] animalsArray = animalManager.GetList().ToArray();
        Object selectedItem = animalManagerListView.SelectedItem;
        int selectedIndex = Array.IndexOf(animalsArray, selectedItem);
        return selectedIndex;
    }

    /// <summary>
    /// Handle select animal
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleSelectedAnimal(object sender, EventArgs e)
    {
        int selectedIndex = GetSelectedAnimalIndex();

        if (selectedIndex != -1)
        {
            Animal animal = animalManager.GetAt(selectedIndex);
            FoodSchedule foodSchedule = animal.GetFoodSchedule();
            string[] meals = foodSchedule.GetMealList();
            animalFoodScheduleContainer.IsVisible = true;
            animalEaterTypeLabel.Text = $"Eater type: {foodSchedule.EaterType}";
            animalBreakfastLabel.Text = $"Breakfast: {meals[0]}";
            animalLunchLabel.Text = $"Lunch: {meals[1]}";
            animalDinnerLabel.Text = $"Dinner: {meals[2]}";
            InitializeAnimalObject(animal);
        }
    }

    /// <summary>
    /// Initialize animal object
    /// </summary>
    /// <param name="animal">Animal object</param>
    private void InitializeAnimalObject(Animal animal)
    {
        animalNameEntry.Text = animal.Name;
        animalAgeEntry.Text = animal.Age.ToString();
        animalGenderPicker.SelectedItem = animal.Gender.ToString();
        animalCategoryPicker.SelectedItem = animal.Category.ToString();

        switch (animal)
        {
            case Dog dog:
                InitializeMammalElements();
                InitializeDogElements();
                mammalPicker.SelectedItem = EMammal.Dog.ToString();
                mammalNumberOfTeethEntry.Text = dog.NumberOfTeeth.ToString();
                dogBreedEntry.Text = dog.Breed;
                break;

            case Monkey monkey:
                InitializeMammalElements();
                InitializeMonkeyElements();
                mammalPicker.SelectedItem = EMammal.Monkey.ToString();
                mammalNumberOfTeethEntry.Text = monkey.NumberOfTeeth.ToString();
                monkeyColorEntry.Text = monkey.Color;
                break;

            case Snake snake:
                InitializeReptileElements();
                InitializeSnakeElements();
                reptilePicker.SelectedItem = EReptile.Snake.ToString();
                reptileIsDeadlyCheckbox.IsChecked = snake.IsDeadly;
                snakeLengthEntry.Text = snake.Length.ToString();
                break;

            case Lizard lizard:
                InitializeReptileElements();
                InitializeLizardElements();
                reptilePicker.SelectedItem = EReptile.Lizard.ToString();
                reptileIsDeadlyCheckbox.IsChecked = lizard.IsDeadly;
                lizardTailLengthEntry.Text = lizard.TailLength.ToString();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Handle change animal
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleChangeAnimal(object sender, EventArgs e)
    {
        int selectedIndex = GetSelectedAnimalIndex();

        if (selectedIndex != -1)
        {
            if (ValidateDefaultAnimal() && ValidateCategory())
            {
                Animal animal = animalManager.GetAt(selectedIndex);
                string id = animal.Id;
                string name = animalNameEntry.Text;
                int age = int.Parse(animalAgeEntry.Text);
                EAnimalGender gender = (EAnimalGender)Enum.Parse(typeof(EAnimalGender), animalGenderPicker.SelectedItem.ToString());
                EAnimalCategory category = (EAnimalCategory)Enum.Parse(typeof(EAnimalCategory), animalCategoryPicker.SelectedItem.ToString());

                switch (category)
                {
                    case EAnimalCategory.Mammal:
                        EMammal mammalType = (EMammal)Enum.Parse(typeof(EMammal), mammalPicker.SelectedItem.ToString());
                        int numberOfTeeth = int.Parse(mammalNumberOfTeethEntry.Text);

                        switch (mammalType)
                        {
                            case EMammal.Dog:
                                string dogBreed = dogBreedEntry.Text;
                                animal = new Dog(name, age, gender, category, mammalType, numberOfTeeth, dogBreed);
                                ((Dog)animal).Breed = dogBreed;
                                break;

                            case EMammal.Monkey:
                                string monkeyColor = monkeyColorEntry.Text;
                                animal = new Monkey(name, age, gender, category, mammalType, numberOfTeeth, monkeyColor);
                                ((Monkey)animal).Color = monkeyColor;
                                break;
                        }
                        break;

                    case EAnimalCategory.Reptile:
                        EReptile reptileType = (EReptile)Enum.Parse(typeof(EReptile), reptilePicker.SelectedItem.ToString());
                        bool isDeadly = reptileIsDeadlyCheckbox.IsChecked;

                        switch (reptileType)
                        {
                            case EReptile.Lizard:
                                int tailLength = int.Parse(lizardTailLengthEntry.Text);
                                animal = new Lizard(name, age, gender, category, reptileType, isDeadly, tailLength);
                                ((Lizard)animal).TailLength = tailLength;
                                break;

                            case EReptile.Snake:
                                int length = int.Parse(snakeLengthEntry.Text);
                                animal = new Snake(name, age, gender, category, reptileType, isDeadly, length);
                                ((Snake)animal).Length = length;
                                break;
                        }
                        break;
                }
                isSaved = false;
                animalManager.ChangeAnimal(selectedIndex, animal);
                FoodSchedule foodSchedule = animal.GetFoodSchedule();
                string[] meals = foodSchedule.GetMealList();
                animalFoodScheduleContainer.IsVisible = true;
                animalEaterTypeLabel.Text = $"Eater type: {foodSchedule.EaterType}";
                animalBreakfastLabel.Text = $"Breakfast: {meals[0]}";
                animalLunchLabel.Text = $"Lunch: {meals[1]}";
                animalDinnerLabel.Text = $"Dinner: {meals[2]}";
                InitializeOnChange();
            }
        }
    }

    /// <summary>
    /// Handle delete animal
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleDeleteAnimal(object sender, EventArgs e)
    {
        int selectedIndex = GetSelectedAnimalIndex();

        if (selectedIndex != -1)
        {
            isSaved = false;
            animalManager.Delete(selectedIndex);
            InitializeOnChange();

        }
        else
        {
            DisplayValidationMessage("Error", "Please select animal");
        }
    }

    /// <summary>
    /// Initialize ingredient on update
    /// </summary>
    private void InitializeIngredientOnUpdate()
    {
        ingredientEntry.Text = string.Empty;
        ingredientListView.ItemsSource = meal.Ingredients.GetList();
        ingredientsLabel.Text = $"Displays {meal.Ingredients.Count} of {meal.Ingredients.Count} ingredients!";

        if (meal.Ingredients.Count == 0)
        {
            ingredientLabel.IsVisible = false;
        }
    }

    /// <summary>
    /// Initialize meal on update
    /// </summary>
    private void InitializeMealOnUpdate()
    {
        foodNameEntry.Text = string.Empty;
        ingredientsLabel.Text = string.Empty;
        ingredientListView.ItemsSource = null;
        animalForm.IsVisible = true;
        foodForm.IsVisible = false;
        animalMealListView.ItemsSource = meals.ToList();
        mealListView.ItemsSource = meals.ToList();
        mealLabel.Text = $"Displays {meals.Count} of {meals.Count} meals!";

        if (meals.Count == 0)
        {
            mealLabel.IsVisible = false;
        }
    }

    /// <summary>
    /// Handle food form
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleFoodForm(object sender, EventArgs e)
    {
        animalForm.IsVisible = false;
        foodForm.IsVisible = true;
    }

    /// <summary>
    /// Get index of selected ingredient
    /// </summary>
    private int GetSelectedIngredientIndex()
    {
        string selectedIngredient = (string)ingredientListView.SelectedItem;
        List<string> ingredients = meal.Ingredients.GetList();
        return ingredients.IndexOf(selectedIngredient);
    }

    /// <summary>
    /// Handle selected ingredient
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleSelectedIngredient(Object sender, EventArgs e)
    {
        int selectedIndex = GetSelectedIngredientIndex();
        ingredientEntry.Text = meal.Ingredients.GetAt(selectedIndex);
    }

    /// <summary>
    /// Handle add ingredient
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleAddIngredient(object sender, EventArgs e)
    {
        if (meal == null)
        {
            meal = new FoodItem();
        }

        if (!ValidateEntryString(ingredientEntry))
        {
            DisplayValidationMessage("Error", "Please enter ingredient!");
            return;
        }
        meal.Ingredients.Add(ingredientEntry.Text);
        InitializeIngredientOnUpdate();
    }

    /// <summary>
    /// Handle change ingredient
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleChangeIngredient(object sender, EventArgs e)
    {
        int selectedIndex = GetSelectedIngredientIndex();

        if (meal == null)
        {
            meal = new FoodItem();
        }

        if (!ValidateEntryString(ingredientEntry) || selectedIndex == -1)
        {
            DisplayValidationMessage("Error", "Please enter ingredient!");
            return;
        }
        meal.Ingredients.Change(selectedIndex, ingredientEntry.Text);
        InitializeIngredientOnUpdate();
    }

    /// <summary>
    /// Handle delete ingredient
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleDeleteIngredient(object sender, EventArgs e)
    {
        int selectedIndex = GetSelectedIngredientIndex();

        if (selectedIndex != -1)
        {
            meal.Ingredients.Delete(selectedIndex);
            InitializeIngredientOnUpdate();
        }
    }

    /// <summary>
    /// Get index of selected meal
    /// </summary>
    private int GetSelectedMealIndex()
    {
        FoodItem[] foodItemArr = meals.ToArray();
        Object selectedItem = mealListView.SelectedItem;
        return Array.IndexOf(foodItemArr, selectedItem);
    }

    /// <summary>
    /// Handle add meal
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleAddMeal(object sender, EventArgs e)
    {
        if (!ValidateEntryString(foodNameEntry))
        {
            DisplayValidationMessage("Error", "Please enter name of meal!");
            return;
        }
        meal.Id = $"M{meals.Count + 1}";
        meal.Name = foodNameEntry.Text;
        meals.Add(meal);
        InitializeMealOnUpdate();
        meal = new FoodItem();
    }

    /// <summary>
    /// Handle delete meal
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleDeleteMeal(object sender, EventArgs e)
    {
        int selectedIndex = GetSelectedMealIndex();

        if (selectedIndex != -1)
        {
            meals.RemoveAt(selectedIndex);
            InitializeMealOnUpdate();
        }
        else
        {
            DisplayValidationMessage("Error", "Please select meal!");
        }
    }

    /// <summary>
    /// Handle cancel food form
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleCancelMeal(object sender, EventArgs e)
    {
        InitializeMealOnUpdate();
    }

    /// <summary>
    /// Handle new file
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private async void HandleNewFile(object sender, EventArgs e)
    {
        if(!isSaved)
        {
            bool initialize = !await DisplayAlert("Initialize new WTS", "Are you sure you want to initialize new WTS without saving?", "Cancel", "Initialize new");
            if (initialize)
            {
                InitializeOnOpen();
                filePath = string.Empty;
            }
        }
        else
        {
            InitializeOnOpen();
            filePath = string.Empty;
        }
    }

    /// <summary>
    /// Handle open file
    /// </summary>
    /// <param name="fileExtension">File extension</param>
    /// <param name="fileName">File name</param>
    private async void OpenFile(string fileExtension, string fileName)
    {
        try
        {
            FileResult filePickerResult = await FilePicker.PickAsync();
            if (filePickerResult != null)
            {
                if (filePickerResult.FileName.EndsWith($"{fileExtension}", StringComparison.OrdinalIgnoreCase))
                {
                    filePath = filePickerResult.FullPath;
                    try
                    {
                        InitializeOnOpen();
                        Stream stream = await filePickerResult.OpenReadAsync();
                        List<Animal> deserializedList = animalManager.DeserializeJSON<Animal>(stream);

                        if (deserializedList != null)
                        {
                            foreach (Animal animal in deserializedList)
                            {
                                animalManager.AddAnimal(animal);
                            }
                            InitializeOnChange();
                        }
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Error", $"Error: {ex.Message}", "Continue");
                    }
                }
                else
                {
                    await DisplayAlert("Error", $"Please select {fileName} File!", "Continue");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error: {ex.Message}", "Continue");
        }
    }

    /// <summary>
    /// Handle open txt file
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private async void HandleOpenAsTxtFile(object sender, EventArgs e)
    {
        OpenFile("txt", "Text");
    }

    /// <summary>
    /// Handle open JSON file
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private async void HandleOpenAsJSONFile(object sender, EventArgs e)
    {
        OpenFile("json", "JSON");
    }

    /// <summary>
    /// Handle save file
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private async void HandleSaveFile(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(filePath))
            {
                FileSaverResult fileSaverResult = await FileSaver.Default.SaveAsync($"animals.json", animalManager.SerializeJSON(animalManager.GetList()), default);

                if (fileSaverResult.IsSuccessful)
                {
                    isSaved = true;
                    await DisplayAlert("Success", $"Animals saved to {fileSaverResult.FilePath}!", "Continue");
                }
                else
                {
                    await DisplayAlert("Error", $"Could not save animals!", "Continue");
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    MemoryStream jsonStream = animalManager.SerializeJSON(animalManager.GetList());
                    await jsonStream.CopyToAsync(writer.BaseStream);
                    isSaved = true;
                    await DisplayAlert("Success",$"Animals saved to {filePath}!", "Continue");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error: {ex.Message}", "Continue");
        }
    }

    /// <summary>
    /// Handle save file
    /// </summary>
    /// <param name="fileExtension">File extension</param>
    /// <param name="fileName">File name</param>
    private async void SaveFile(string fileExtension, string fileName)
    {
        try
        {
            FileSaverResult fileSaverResult = await FileSaver.Default.SaveAsync($"animals.{fileExtension}", animalManager.SerializeJSON(animalManager.GetList()), default);

            if (fileSaverResult.IsSuccessful)
            {
                isSaved = true;
                await DisplayAlert("Success", $"Animals saved to {fileName} File!", "Continue");
            }
            else
            {
                await DisplayAlert("Error", $"Could not save animals to {fileName} File!", "Continue");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error: {ex.Message}", "Continue");
        }
    }

    /// <summary>
    /// Handle save as txt file
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private async void HandleSaveAsTxtFile(object sender, EventArgs e)
    {
        SaveFile("txt", "Text");
    }

    /// <summary>
    /// Handle save as JSON file
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private async void HandleSaveAsJSONFile(object sender, EventArgs e)
    {
        SaveFile("json", "JSON");
    }

    /// <summary>
    /// Handle exit
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private async void HandleExit(object sender, EventArgs e)
    {
        if (!isSaved)
        {
            bool exit = !await DisplayAlert("Exit WTS", "Are you sure you want to exit the WTS without saving?", "Cancel", "Exit");
            if (exit)
            {
                Application.Current.Quit();
            }
        }
        else
        {
            bool exit = !await DisplayAlert("Exit WTS", "Are you sure you want to exit the WTS?", "Cancel", "Exit");
            if (exit)
            {
                Application.Current.Quit();
            }
        }
    }
}