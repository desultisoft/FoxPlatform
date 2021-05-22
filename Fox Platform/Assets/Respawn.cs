using UnityEngine;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    public UnityEvent onSetRespawn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            if (player.respawn != transform && transform.position.x > player.respawn.transform.position.x)
            {
                player.respawn = gameObject;
                onSetRespawn.Invoke();
            }
        }
    }
}
