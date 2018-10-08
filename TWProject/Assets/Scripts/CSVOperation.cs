using UnityEngine;

public class CSVOperations : MonoBehaviour
{
    public static string[] Load(string Table)
    {
        TextAsset rawData = Resources.Load("CSV/" + Table, typeof(TextAsset)) as TextAsset;
        if (rawData == null)
        {
            Debug.LogError("CSV read error.");
            return null;
        }
        else
        {
            return rawData.text.Split('\n');
        }
    }
}
