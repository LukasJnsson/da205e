
/*
Lukas Jönsson
12/04-2024
*/

using System.Windows.Threading;
namespace Solution_Assignment_5;


/// <summary>
/// Airplane class
/// </summary>
public class Airplane
{
    /// <summary>
    /// Private attributes and auto-properties
    /// </summary>
    private DispatcherTimer dispatcherTimer;
    public bool IsInAir { get; set; }
    public string FlightName { get; set; }
    public string Destination { get; set; }
    public string FlightId { get; set; }
    public double FlightTime { get; set; }
    public double RemainingFlightTime { get; set; }
    public TimeOnly LocalTime { get; set; }

    /// <summary>
    /// Public events
    /// </summary>
    public event EventHandler<AirplaneEventArgs> TakeOffEvent;
    public event EventHandler<AirplaneEventArgs> LandedEvent;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="flightName">Flight name</param>
    /// <param name="destination">Destination</param>
    /// <param name="flightId">Flight id</param>
    /// <param name="flightTime">Flight time</param>
    public Airplane(string flightName, string destination, string flightId, double flightTime)
    {
        IsInAir = false;
        FlightName = flightName;
        Destination = destination;
        FlightId = flightId;
        FlightTime = flightTime;
        RemainingFlightTime = flightTime;
        LocalTime = TimeOnly.FromDateTime(DateTime.Now);
    }

    /// <summary>
    /// Set the timer
    /// </summary>
    public void SetupTimer()
    {
        dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        dispatcherTimer.Tick += new EventHandler(HandleLanding);
        dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        dispatcherTimer.Start();
    }

    /// <summary>
    /// Stop the timer
    /// </summary>
    public void StopTimer()
    {
        dispatcherTimer?.Stop();
    }

    /// <summary>
    /// Land airplane
    /// </summary>
    public void Land()
    {
        IsInAir = false;
        StopTimer();
        /*
        * Arrival time equals LocalTime + FlightTime
        */
        LocalTime = new TimeOnly(LocalTime.ToTimeSpan().Add(TimeSpan.FromHours(FlightTime)).Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
        LandedEvent?.Invoke(this, new AirplaneEventArgs("Landed", $"{FlightName} ({FlightId}) has landed in {Destination} - {LocalTime.ToLongTimeString()}"));
        Destination = "Copenhagen";
    }

    /// <summary>
    /// Take off airplane
    /// </summary>
    public void TakeOff()
    {
        if (!IsInAir)
        {
            IsInAir = true;
            RemainingFlightTime = FlightTime;
            /*
            * Departure time
            */
            LocalTime = new TimeOnly(LocalTime.Hour, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
            SetupTimer();
            TakeOffEvent?.Invoke(this, new AirplaneEventArgs("TakeOff", $"{FlightName} ({FlightId}) towards {Destination} is taking off - {LocalTime.ToLongTimeString()}"));
        }
    }

    /// <summary>
    /// Handle the flight time and landing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleLanding(object? sender, EventArgs e)
    {
        RemainingFlightTime--; // Decrease by one
        if (RemainingFlightTime <= 0)
        {
            Land();
        }
    }

    /// <summary>
    /// ToString
    /// </summary>
    /// <returns>Airplane attributes in string</returns>
    public override string ToString()
    {
        return $"Flight: {FlightName} ({FlightId}) Destination: {Destination} (Flight Time: {FlightTime}h)";
    }
}