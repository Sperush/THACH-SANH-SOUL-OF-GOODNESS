using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void Swap<T>(this IList<T> list, int indexA, int indexB)
    {
        if (indexA < 0 || indexA >= list.Count || indexB < 0 || indexB >= list.Count)
        {
            // Trong Unity, nên dùng Debug.LogError thay vì throw exception nếu có thể tránh được
            Debug.LogError("Swap Index nằm ngoài phạm vi của danh sách.");
            return;
        }

        T temp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = temp;
    }
}