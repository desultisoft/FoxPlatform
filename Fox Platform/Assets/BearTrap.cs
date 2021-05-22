using System;
using Items;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Items
{
    public class BearTrap : Item
    {
        public PlacedBearTrap trap;
        public override void Use(Player user)
        {
            PlacedBearTrap newTrap = Instantiate(trap, user.transform.position, user.transform.rotation, null);
            newTrap.OnCreated(user);
            if (newTrap)
            {
                user.itemManager.UnEquip();
            }
                
        }
    }
}