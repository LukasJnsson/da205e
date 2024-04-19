
/*
Lukas Jönsson
12/04-2024
*/

namespace Solution_Assignment_5;


/// <summary>
/// AirplaneEventArgs class
/// </summary>
public class AirplaneEventArgs : EventArgs
{
    /// <summary>
    /// Auto-properties
    /// </summary>
    public string Name { get; set; }
    public string Message { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name of event</param>
    /// <param name="message">Message of event</param>
    public AirplaneEventArgs(string name, string message)
    {
        Name = name;
        Message = message;
    }
}