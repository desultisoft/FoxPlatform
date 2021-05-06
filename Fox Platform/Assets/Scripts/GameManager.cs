using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Player[] players { get; private set; }

    public void Start()
    {
        SceneManager.LoadScene ("UI", LoadSceneMode.Additive);
        Spawn.Instance.CreatePlayer(2);
        players = FindObjectsOfType<Player>();
        EnablePlayers(false);
    }
    
    public void EnablePlayers(bool isOn)
    {
        foreach (var player in players)
        {
            player.movement.enabled = isOn;
        }
    }
    
    public void StartGame()
    {
        //Remake the level.
        LevelManager.Instance.MakeLevel();
        //Setup the players in the right position and setup their data if need be.
        foreach (var player in players)
            player.Reset();
    }
}
