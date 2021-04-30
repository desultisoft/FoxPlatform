using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform spawnPoint;
    public float minHeightForDeath = -6f;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < minHeightForDeath)
            Reset();
    }
    public void Reset()
    {
        gameObject.transform.position = spawnPoint.position;
    }
}
