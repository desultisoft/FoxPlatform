using TWGFramework;
using UnityEngine;

public class WinZone : MonoBehaviour
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
