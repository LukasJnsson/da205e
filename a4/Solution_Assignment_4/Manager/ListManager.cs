
/* 
Lukas Jönsson
29/3-2024
*/

using Newtonsoft.Json;
using System.Text;
namespace Solution_Assignment_4.Manager;


/// <summary>
/// ListManager class
/// </summary>
public class ListManager<T> : IListManager<T>
{
    /// <summary>
    /// Private attribute
    /// </summary>
    private List<T> tList;

    /// <summary>
    /// ListManager constructor
    /// </summary>
    public ListManager()
    {
        tList = new List<T>();
    }

    /// <summary>
    /// Add object
    /// </summary>
    /// <param name="aType">Object of type T</param>
    /// <returns>True in case object is added, otherwise false</returns>
    public bool Add(T aType)
    {
        bool isValid = false;

        if (aType != null)
        {
            tList.Add(aType);
            isValid = true;
        }
        return isValid;
    }

    /// <summary>
    /// Delete object
    /// </summary>
    /// <param name="index">Index</param>
    /// <returns>True in case object is deleted, otherwise false</returns>
    public bool Delete(int index)
    {
        bool isValid = false;

        if (index >= 0 && index < tList.Count)
        {
            tList.RemoveAt(index);
            isValid = true;
        }
        return isValid;
    }

    /// <summary>
    /// Change object
    /// </summary>
    /// <param name="index">Index</param>
    /// <param name="aType">Object of type T</param>
    /// <returns>True in case object is not null and inside index, otherwise false</returns>
    public bool Change(int index, T aType)
    {
        bool isValid = false;

        if (aType != null)
        {
            if (index >= 0 && index < tList.Count)
            {
                tList[index] = aType;
                isValid = true;
            }
        }
        return isValid;
    }

    /// <summary>
    /// Returns object at index
    /// </summary>
    /// <param name="index">Index</param>
    /// <returns>Object at index</returns>
    public T GetAt(int index)
    {
        if (index >= 0 && index < tList.Count)
        {
            return tList[index];
        }
        else
        {
            return default(T);
        }
    }

    /// <summary>
    /// Returns list with the objects
    /// </summary>
    /// <returns>List with the objects</returns>
    public List<T> GetList()
    {
        List<T> copyTList = new List<T>();

        foreach (T obj in tList)
        {
            copyTList.Add(obj);
        }
        return copyTList;
    }

    /// <summary>
    /// Returns array with each objects ToString()
    /// </summary>
    /// <returns>String array with the objects ToString()</returns>
    public string[] GetStringArray()
    {
        string[] objectArr = new string[tList.Count];

        for (int i = 0; i < tList.Count; i++)
        {
            objectArr[i] = tList[i].ToString();
        }
        return objectArr;
    }

    /// <summary>
    /// Count property
    /// </summary>
    public int Count
    {
        get { return tList.Count; }
    }

    /// <summary>
    /// Serialize list
    /// </summary>
    /// <param name="list">List with objects</param>
    /// <returns>MemoryStream with the serialized JSON list</returns>
    public MemoryStream SerializeJSON(List<T> list)
    {
        try
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                /*
                * Set indentation and include types in serialization, based on the following sources
                * https://www.newtonsoft.com/json/help/html/t_newtonsoft_json_typenamehandling.htm
                * https://www.newtonsoft.com/json/help/html/serializetypenamehandling.htm
                */
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            string serializedList = JsonConvert.SerializeObject(list, settings);
            return new MemoryStream(Encoding.UTF8.GetBytes(serializedList));
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    /// <summary>
    /// Deserialize list
    /// </summary>
    /// <param name="stream">Stream</param>
    /// <returns>List with the deserialized JSON objects</returns>
    public List<T> DeserializeJSON<T>(Stream stream)
    {
        try
        {
            string serializedList = new StreamReader(stream).ReadToEnd();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.DeserializeObject<List<T>>(serializedList, settings);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}