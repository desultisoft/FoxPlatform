using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    public Tilemap[] maps;
    public float width;
    private Bounds bounds;
    public void Awake()
    {
        maps = GetComponentsInChildren<Tilemap>();
        foreach (var map in maps)
        {
            var cellBounds = map.cellBounds;
            var mapbounds = map.localBounds;
            
            //map.CompressBounds();
            
            bounds.Encapsulate(mapbounds);
        }

        width = bounds.size.x;

    }
}
