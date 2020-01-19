using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public static class ListUtills
{
    public static int ClampIndex(this ICollection collection, int index)
    {
        return Mathf.Clamp(index, 0, collection.Count - 1);
    }

    public static int ClampIndexCircle(this ICollection collection, int index)
    {
        if (index >= collection.Count)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = collection.Count - 1;
        }

        return index;
    }

    public static string ToJoinedString<T, H>(this ICollection<T> list, Func<T, H> result, string separator = ",")
    {
        return string.Join(separator, list.Select(result).ToArray());
    }

    public static T GetRandomElement<T>(this ICollection<T> list)
    {
        return list.ElementAt(Random.Range(0, list.Count));
    }
}
