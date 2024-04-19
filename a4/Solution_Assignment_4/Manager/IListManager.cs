
/* 
Lukas Jönsson
29/3-2024
*/

namespace Solution_Assignment_4.Manager;


/// <summary>
/// List manager interface
/// </summary>
public interface IListManager<T>
{
    /// <summary>
    /// Add object of type T to list
    /// </summary>
    /// <param name="aType">Object</param>
    /// <returns>True in case object is added, otherwise false</returns>
    bool Add(T aType);

    /// <summary>
    /// Delete object of type T from list
    /// </summary>
    /// <param name="index">Index</param>
    /// <returns>True in case object is deleted, otherwise false</returns>
    bool Delete(int index);

    /// <summary>
    /// Change object of type T in list
    /// </summary>
    /// <param name="index">Index</param>
    /// <param name="aType">Object</param>
    /// <returns>True in case the object is changed, otherwise false</returns>
    bool Change(int index, T aType);

    /// <summary>
    /// Get object of type T at index
    /// </summary>
    /// <param name="index">Index</param>
    /// <returns>Object of type T if inside the index, otherwise null</returns>
    T GetAt(int index);

    /// <summary>
    /// Get list with the objects
    /// </summary>
    /// <returns>List with the objects</returns>
    List<T> GetList();

    /// <summary>
    /// Get array with each objects ToString()
    /// </summary>
    /// <returns>Array with each objects ToString()</returns>
    string[] GetStringArray();

    /// <summary>
    /// Get the number of objects in the list
    /// </summary>
    int Count { get; }


    /// <summary>
    /// Serialize JSON
    /// </summary>
    /// <param name="list">List</param>
    /// <returns></returns>
    MemoryStream SerializeJSON(List<T> list);

    /// <summary>
    /// Deserialize JSON
    /// </summary>
    /// <param name="stream">Stream</param>
    /// <returns></returns>
    List<T> DeserializeJSON<T>(Stream stream);
}