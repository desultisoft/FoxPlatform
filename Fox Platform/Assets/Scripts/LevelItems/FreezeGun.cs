using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Items
{
    public class FreezeGun : Item
    {
        public Transform muzzle;
        public int maxBullets;
        public Bullet bullet;

        public override void Use(Player user)
        {
            Bullet newBullet = Instantiate(bullet);
            
                newBullet.transform.position = muzzle.position;
                if (!user.isRight)
                {
                    newBullet.velX = -newBullet.velX;
                }

                maxBullets--;
                
                if (maxBullets <= 0)
                {
                    //Consume the gun.
                    user.itemManager.UnEquip();
                }
        }
    }
}