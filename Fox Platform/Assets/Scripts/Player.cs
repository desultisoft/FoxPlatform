using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement;
    public int ID;
    public float minHeightForDeath = -6f;
    // Update is called once per frame

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(gameObject.transform.position.y < minHeightForDeath)
            Reset();
    }
    public void Reset()
    {
        Spawn.Instance.Respawn(this);
    }
}
