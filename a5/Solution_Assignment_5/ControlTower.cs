
/*
Lukas Jönsson
12/04-2024
*/

using System.Windows.Controls;
using Solution_Assignment_5.Manager;
namespace Solution_Assignment_5;


/// <summary>
/// ControlTower class
/// </summary>
public class ControlTower
{
    /// <summary>
    /// Private attributes
    /// </summary>
    private ListManager<Airplane> flights;
    private ListView flightsListView;
    private ListBox flightsInMovementListBox;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="flightsListView">Flights list view</param>
    /// <param name="flightsInMovementListBox">Flights in movement list box</param>
    public ControlTower(ListView flightsListView, ListBox flightsInMovementListBox)
    {
        flights = new ListManager<Airplane>();
        this.flightsListView = flightsListView;
        this.flightsInMovementListBox = flightsInMovementListBox;
    }

    /// <summary>
    /// Add airplane
    /// </summary>
    /// <param name="airplane">Airplane object</param>
    public void AddAirPlane(Airplane airplane)
    {
        flights.Add(airplane);
        airplane.TakeOffEvent += HandleTakeOffEvent;
        airplane.LandedEvent += HandleLandedEvent;
        flightsListView.ItemsSource = null;
        flightsListView.ItemsSource = flights.GetList();
    }

    /// <summary>
    /// Get airplane at index
    /// </summary>
    /// <param name="index">Index</param>
    /// <returns>Airplane object</returns>
    public Airplane GetAirPlane(int index)
    {
        return flights.GetAt(index);
    }

    /// <summary>
    /// Take off airplane
    /// </summary>
    /// <param name="index">Index</param>
    public void TakeOffAirPlane(int index)
    {
        Airplane airplane = flights.GetAt(index);
        airplane.TakeOff();
    }

    /// <summary>
    /// Land airplane
    /// </summary>
    /// <param name="index">Index</param>
    public void LandAirPlane(int index)
    {
        Airplane airplane = flights.GetAt(index);
        airplane.Land();
    }

    /// <summary>
    /// Handle take off event
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleTakeOffEvent(object? sender, AirplaneEventArgs e)
    {
        flightsInMovementListBox.Items.Add(e.Message);
    }

    /// <summary>
    /// Handle landed event
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleLandedEvent(object? sender, AirplaneEventArgs e)
    {
        flightsInMovementListBox.Items.Add(e.Message);
    }
}