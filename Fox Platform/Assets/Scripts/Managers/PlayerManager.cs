using System;
using System.Collections;
using System.Collections.Generic;
using TWGFramework;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerManager : Singleton<PlayerManager>
{
    public int numPlayers = 2;
    public PlayerArgEvent onPlayerCreate;
    public List<Player> players { get; private set; }

    public Color[] pColors;
    public GameObject pCamera;
    public Player playerPrefab;

    public void Start()
    {
        players = new List<Player>();
    }

    public void CreatePlayers()
    {
        for (int i = 0; i < numPlayers; i++)
        {
            if(playerPrefab == null)
                Debug.Break();
            
            int ID = i + 1;
            
            Player newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity, transform);
            if (newPlayer == null)
            {
                Debug.LogError("Null Player.");
                Debug.Break();
            }
            players.Add(newPlayer);
            newPlayer.ID = ID;
            newPlayer.color = pColors[i];
            newPlayer.GetComponent<SpriteRenderer>().color = pColors[i];
            newPlayer.GetComponent<SpriteRenderer>().sortingOrder = ID;
            newPlayer.gameObject.name = "Player " + ID;
            pCamera.SetActive(false);
            GameObject newSplitter = Instantiate(pCamera);
            newSplitter.transform.position = new Vector3(0, -0.75f, -1.75f);
            //newSplitter.transform.position = Vector3.zero;
            Camera playerCamera = newSplitter.GetComponentInChildren<Camera>();

            newPlayer.cameraController.Init(playerCamera);
            
            string layermaskname = ID + "PlayerOnly";
            int ourLayerMask = LayerMask.NameToLayer(layermaskname);
            playerCamera.LayerCullingShow(layermaskname);
            pCamera.SetActive(true);
            newSplitter.SetActive(true);
            foreach (Parallax parallax in newSplitter.GetComponentsInChildren<Parallax>())
            {
                parallax.gameObject.layer = ourLayerMask;
                parallax.subject = newPlayer.transform;
                parallax.Init();
            }

            newSplitter.GetComponentInChildren<FollowGameObject>().toFollow = newPlayer.gameObject;

            PlayerMovement movement = newPlayer.GetComponent<PlayerMovement>();
            
            movement.HorizontalInput = "Horizontal" + ID;
            movement.CrouchInput = "Crouch" + ID;
            movement.JumpInput = "Jump" + ID;
            movement.InteractInput = "Interact" + ID;
            
            if (newPlayer.respawn == null) 
                newPlayer.respawn = LevelManager.Instance.gameObject;
            
            Respawn(newPlayer);
            
            onPlayerCreate.Raise(newPlayer);
        }
    }
    
    public void Respawn(Player player)
    {
        player.transform.position = player.respawn.transform.position +Vector3.right * Random.Range(-0.1f,0.1f);
    }
}
