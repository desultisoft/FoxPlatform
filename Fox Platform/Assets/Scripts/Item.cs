using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void Use(Player user);

    public virtual void OnEquip(Player equipper)
    {
        //Turn left if needed.
        if (!equipper.isRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    public virtual void OnUnEquip(){ }
}