using System;
using System.Collections;

public static class Extension
{
    static Random random = new Random();

    public static void Shuffle<T>(this T[] data)
    {
        for (int i = data.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            (data[j], data[i]) = (data[i], data[j]);
        }
    }

    public static IEnumerator CoroutineShuffle<T>(this T[] data, Action Callback = null)
    {
        for (int i = data.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);
            (data[j], data[i]) = (data[i], data[j]);
            yield return null;
        }
        Callback.Invoke();
    }
}
