using System.Collections.Generic;
using UnityEngine;

namespace Project.Pickups
{
    public abstract class PickupSO : ScriptableObject
    {
        public PickupPoolSO Pool = null;

        public Pickup Request()
        {
            Pickup pickup = Pool.Request();
            pickup.PickupData = this;
            pickup.Pool = Pool;
            return pickup;
        }

        public List<Pickup> Request(int amount)
        {
            List<Pickup> pickups = Pool.Request(amount);

            for (int i = 0; i < amount; i++)
            {
                pickups[i].PickupData = this;
                pickups[i].Pool = Pool;
            }

            return pickups;
        }
    }
}
