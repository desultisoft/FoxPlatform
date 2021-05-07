using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : Singleton<Spawn>
{
    public Color[] pColors;
    public CameraSplitter splitter;
    public Player playerPrefab;
    public void CreatePlayer(int numPlayers)
    {
        for (int i = 0; i < numPlayers; i++)
        {
            int ID = i + 1;
            
            Player newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity, transform);
            
            newPlayer.GetComponent<SpriteRenderer>().color = pColors[i];
            newPlayer.GetComponent<SpriteRenderer>().sortingOrder = ID;
            newPlayer.gameObject.name = "Player " + ID;
            
            CameraSplitter newSplitter = Instantiate(splitter);
            newSplitter.GetComponent<FollowGameObject>().toFollow = newPlayer.gameObject;
            
            PlayerMovement movement = newPlayer.GetComponent<PlayerMovement>();
            
            movement.HorizontalInput = "Horizontal" + ID;
            movement.CrouchInput = "Crouch" + ID;
            movement.JumpInput = "Jump" + ID;
            movement.InteractInput = "Interact" + ID;
            
            Respawn(newPlayer);
        }
    }
    
    public void Respawn(Player player)
    {
        player.transform.position = LevelManager.Instance.respawnPoint.position +Vector3.right * Random.Range(-1f,1f);
    }
}
