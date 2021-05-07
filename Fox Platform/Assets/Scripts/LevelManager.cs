using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    static System.Random random = new System.Random();
    public static List<T> GenerateRandom<T>(this List<T> collection, int count)
    {
        return collection.OrderBy(d => random.Next()).Take(count).ToList();
    }
}

public class LevelManager : Singleton<LevelManager>
{
    public GameObject currentLevel;
    
    public Transform respawnPoint;
    public Room startRoom;
    public Room endRoom;
    public int RoomsPerLevel = 3;
    public LevelSet levels;
    private List<Room> currentRooms;
    private Room previousRoom;
    private bool isLastRoom;
    private bool isFirstRoom;
    void Start()
    {
        MakeLevel();
    }
    
    
    public Rect rect;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
    }

    public void MakeLevel()
    {
        //If we already have a level kill it.
        if(currentLevel)
            Destroy(currentLevel);
        
        //Make a new one.
        currentLevel = new GameObject();
        currentLevel.gameObject.name = "CurrentLevel";
        currentLevel.gameObject.transform.parent = transform;
        
        Vector3 roomPos = Vector3.zero;
        
        //Create the start of a level.
        Room startingRoomGO = Instantiate(startRoom);
        startingRoomGO.transform.SetParent(currentLevel.transform);
        previousRoom = startingRoomGO;
        
        //Create the respawn
        GameObject spawn = new GameObject();
        spawn.transform.position = startingRoomGO.transform.position;
        spawn.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 10,
            spawn.transform.position.z);
        spawn.gameObject.name = "spawn";
        spawn.transform.SetParent(currentLevel.transform);
        respawnPoint = spawn.transform;
        
        //Filler of the level.
        currentRooms = levels.GetRandomRooms(RoomsPerLevel);
        for (int i = currentRooms.Count-1; i >= 0; i--)
        {
            Room roomPrefab = currentRooms[i];
            Room roomGO = Instantiate(roomPrefab);
            roomGO.transform.SetParent(currentLevel.transform);
            roomPos.x += previousRoom.width;
            roomGO.transform.position = roomPos;
            previousRoom = roomGO;
        }

        Room endRoomGO = Instantiate(endRoom);
        roomPos.x += previousRoom.width;
        endRoomGO.transform.position = roomPos;
        endRoomGO.transform.SetParent(currentLevel.transform);
    }
}