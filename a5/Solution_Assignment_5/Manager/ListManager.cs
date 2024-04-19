
/*
Lukas Jönsson
12/04-2024
*/

namespace Solution_Assignment_5.Manager;


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
    /// Constructor
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
}