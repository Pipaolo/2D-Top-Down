using Interfaces;
using UnityEngine;

namespace Core.CoreComponents
{
    public class Combat : CoreComponent, IDamageable 
    {

        public void Damage(float damageAmount)
        {
            Debug.Log(Core.transform.parent.name + " Damaged!" + damageAmount);
            Core.Stats.DecreaseHealth(damageAmount);
        }
    }
}