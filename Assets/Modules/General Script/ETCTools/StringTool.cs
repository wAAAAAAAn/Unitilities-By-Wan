using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StringTool : MonoBehaviour
{
    static StringBuilder stringBuilder = new StringBuilder();
    public static string ConnectString(string a, string b)
    {
        stringBuilder.Clear();

        stringBuilder.Append(a);
        stringBuilder.Append(b);
        return stringBuilder.ToString();
    }
}
