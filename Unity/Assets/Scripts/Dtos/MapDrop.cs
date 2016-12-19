
using UnityEngine;

public class MapDrop {
    public string identifier;
    public float x;
    public float y;

    public static MapDrop CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<MapDrop>(jsonString);
    }
}
