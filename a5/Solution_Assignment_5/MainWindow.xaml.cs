
/*
Lukas Jönsson
12/04-2024
*/

using System.Windows;
using System.Windows.Controls;
namespace Solution_Assignment_5;


/// <summary>
/// MainWindow class
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Private attribute
    /// </summary>
    private ControlTower controlTower;

    /// <summary>
    /// Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        InitializeOutputElements();
        InitializeInputElements();
        controlTower = new ControlTower(flightsListView, flightsInMovementListBox);
    }

    /// <summary>
    /// Initialize output elements
    /// </summary>
    private void InitializeOutputElements()
    {
        flightNameLabel.Content = "Flight Name:";
        flightIdLabel.Content = "Flight ID:";
        flightDestinationLabel.Content = "Flight Destination:";
        flightTimeLabel.Content = "Flight Time:";
        flightAddButton.Content = "Add Flight";
        flightTakeOffButton.Content = "Take Off";
    }

    /// <summary>
    /// Initialize input elements
    /// </summary>
    private void InitializeInputElements()
    {
        flightNameInput.Text = string.Empty;
        flightIdInput.Text = string.Empty;
        flightDestinationInput.Text = string.Empty;
        flightTimeInput.Text = string.Empty;
    }

    /// <summary>
    /// Validate data type of textbox
    /// </summary>
    /// <param name="textBox">TextBox</param>
    /// <returns>True if string, otherwise false</returns>
    private bool ValidateEntryString(TextBox textBox)
    {
        return !string.IsNullOrEmpty(textBox.Text.Trim());
    }

    /// <summary>
    /// Validate data type of textbox
    /// </summary>
    /// <param name="textBox">TextBox</param>
    /// <returns>True if double, otherwise false</returns>
    private bool ValidateEntryDouble(TextBox textBox)
    {
        double validDataType;
        return double.TryParse(textBox.Text.Trim(), out validDataType);
    }

    /// <summary>
    /// Validate flight data
    /// </summary>
    /// <returns>True if valid data types, otherwise false</returns>
    private bool ValidateFlightData()
    {
        bool isValid = true;

        Dictionary<TextBox, string> entriesToValidate = new Dictionary<TextBox, string>
        {
            {flightNameInput, "flight name" },
            {flightIdInput, "flight id" },
            {flightDestinationInput, "flight destination" },
            {flightTimeInput, "flight time" }
        };

        foreach (KeyValuePair<TextBox, string> textbox in entriesToValidate)
        {
            if (textbox.Key == flightTimeInput)
            {
                if (!ValidateEntryDouble(textbox.Key))
                {
                    MessageBox.Show($"Please enter {textbox.Value}!");
                    isValid = false;
                }
            }
            else
            {
                if (!ValidateEntryString(textbox.Key))
                {
                    MessageBox.Show($"Please enter {textbox.Value}!");
                    isValid = false;
                }
            }
        }
        return isValid;
    }

    /// <summary>
    /// Handle add flight
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleAddFlightButton(object sender, EventArgs e)
    {
        if (ValidateFlightData())
        {
            string flightName = flightNameInput.Text;
            string destination = flightDestinationInput.Text;
            string flightId = flightIdInput.Text;
            double flightTime = double.Parse(flightTimeInput.Text);
            Airplane airplane = new(flightName, destination, flightId, flightTime);
            controlTower.AddAirPlane(airplane);
            InitializeInputElements();
        }
    }

    /// <summary>
    /// Validate selected flight
    /// </summary>
    /// <returns>True if flight is selected, otherwise false</returns>
    private bool ValidateSelectedFlight()
    {
        bool isValid = false;

        if (flightsListView.SelectedIndex != -1 )
        {
            isValid = true;
        }
        return isValid;
    }

    /// <summary>
    /// Handle take off flight
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleTakeOffFlightButton(object sender, EventArgs e)
    {
        if (ValidateSelectedFlight())
        {
            int selectedPlaneIndex = flightsListView.SelectedIndex;
            Airplane selectedPlane = controlTower.GetAirPlane(selectedPlaneIndex);

            if (selectedPlane.IsInAir)
            {
                MessageBox.Show($"{selectedPlane} is in the air!");
            }
            else
            {
                controlTower.TakeOffAirPlane(selectedPlaneIndex);
            }
        }
        else
        {
            MessageBox.Show("Please select flight!");
        }
    }
}