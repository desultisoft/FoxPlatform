using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float minHeightForDeath;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < minHeightForDeath)
            gameObject.transform.position = spawnPoint.position;
    }
}
