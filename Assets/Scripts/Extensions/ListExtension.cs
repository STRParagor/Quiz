using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ListExtension
{
    /// <summary>
    /// Shuffle list
    /// </summary>
    public static void Shuffle<T>(this List<T> list)
    {
        Random rand = new Random();

        for (int i = list.Count - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);

            T tmp = list[j];
            list[j] = list[i];
            list[i] = tmp;
        }
    }

    /// <summary>
    /// Selects one or more random objects from the list
    /// </summary>
    public static List<T> OneOrMoreOf<T>(this List<T> list, int count = 1)
    {
        if (list == null || list.Count == 0) return null;

        List<T> result = new List<T>();
        List<T> randomList = new List<T>();

        foreach (T item in list)
            randomList.Add(item);

        randomList.Shuffle();

        for (int i = 0; i < count; i++)
        {
            if (i >= randomList.Count) break;

            result.Add(randomList[i]);
        }

        return result;
    }
}