using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    AsyncOperation asyncLoadLevel;
    
    IEnumerator Init()
    {
        asyncLoadLevel = SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }

        PlayerManager.Instance.CreatePlayers();
        EnablePlayers(false);
    }
    
    public void Start()
    {
        StartCoroutine(Init());
    }
    
    public void EnablePlayers(bool isOn)
    {
        foreach (var player in PlayerManager.Instance.players)
        {
            player.movement.enabled = isOn;
        }
    }
    
    public void StartGame()
    {
        //Remake the level.
        LevelManager.Instance.MakeLevel();
        //Setup the players in the right position and setup their data if need be.
        foreach (var player in PlayerManager.Instance.players)
        {
            player.respawn = LevelManager.Instance.respawnPoint.gameObject;
            PlayerManager.Instance.Respawn(player);
        }
            
    }
}
