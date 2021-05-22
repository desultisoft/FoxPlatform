using TWGFramework;
using UnityEngine;

public class WinZone : Singleton<WinZone>
{
    public PlayerArgEvent onPlayerWin;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player winner = other.GetComponent<Player>();
        if (winner != null)
        {
            onPlayerWin.Raise(winner);
        }
    }
}
