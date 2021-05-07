using System;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ItemManager itemManager;
    public PlayerMovement movement;
    public bool isRight => movement.controller.m_FacingRight;
    public float minHeightForDeath = -6f;
    // Update is called once per frame
    private void Awake()
    {
        //itemManager = new ItemManager(this);
        itemManager.Init(this);
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
    
    public void Action()
    {
        itemManager.InteractButton();
    }
}
