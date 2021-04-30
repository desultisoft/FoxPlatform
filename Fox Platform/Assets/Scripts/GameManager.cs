using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winnerText;
    private Player[] players;
    private List<Player> winners = new List<Player>();
    public GameObject startScreen;
    public GameObject endScreen;
    
    public void Start()
    {
        winnerText.text = "";
        TitleController.Instance.Animate();
        players = FindObjectsOfType<Player>();
    }

    public void HandlePlayerWin(Player winner)
    {
        StartCoroutine(HandleWin(winner));
    }

    IEnumerator HandleWin(Player winner)
    {
        yield return new WaitForSeconds(1);
        
        if (!winners.Contains(winner))
        {
            winners.Add(winner);
            
            if (winners.Count >= players.Length)
            {
                for (int i = 0; i < winners.Count; i++)
                {
                    winnerText.text += winners[i].gameObject.name + "\n";
                }
                
                EndGame();
            }
            
        }
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
    }
    
    public void StartGame()
    {
        startScreen.SetActive(false);
    }

    public void RestartGame()
    {
        foreach (var player in winners)
        {
            player.Reset();
        }
        
        winnerText.text = "";
        
        winners.Clear();
        
        startScreen.SetActive(false);
        endScreen.SetActive(false);
    }
}
