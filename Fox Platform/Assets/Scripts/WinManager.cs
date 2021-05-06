using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TWGFramework;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Manages a list of winning players and displays results on an end screen.
    /// </summary>
    public class WinManager : MonoBehaviour
    {
        public GameObject endScreen;
        public TextMeshProUGUI winnerText;
        public GameEvent onGameOver;
        public List<Player> winners { private set; get; }

        public void Start()
        {
            winners = new List<Player>();
        }

        public void Reset()
        {
            //Reset UI
            endScreen.SetActive(false);
            winnerText.text = "";
            winners.Clear();
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
                //If we have all our winners populate the winners and show the end screen.
                if (winners.Count >=GameManager.Instance.players.Length)
                {
                    for (int i = 0; i < winners.Count; i++)
                    {
                        winnerText.text += winners[i].gameObject.name + "\n";
                    }
                    onGameOver.Raise();
                }
            }
        }
    }
}