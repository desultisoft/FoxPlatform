using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelSet")]
public class LevelSet : ScriptableObject
{
    public List<Room> Levels;
    public List<Room> GetRandomRooms(int roomsPerLevel)
    {
        return Levels.GenerateRandom(roomsPerLevel);
    }
}