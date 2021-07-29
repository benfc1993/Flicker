using System.Collections.Generic;

public static class ArrayExtensions
{
    ////<summary>
    /// Returns a random element from the array
    public static T Random<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }
    
    /// <summary>
    /// Returns the last item in an array
    /// </summary>
    public static T Last<T>(this T[] list)
    {
        if(list.Length > 0) return list[list.Length - 1];
        return list[0];
    }
    
    ////<summary>
    /// Returns a random element from the list
    public static T Random<T>(this List<T> list )
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    /// <summary>
    /// Returns the last item in a list
    /// </summary>
    public static T Last<T>(this List<T> list)
    {
        if(list.Count > 0) return list[list.Count - 1];
        return list[0];
    }
}
