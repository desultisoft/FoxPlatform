using UnityEngine;

public class ParentOnTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.parent = transform;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }
}