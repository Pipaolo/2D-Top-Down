using System;
using System.Collections.Generic;
using Interfaces;
using Player.PlayerStates.SubStates;
using ScriptableObjects.Weapons;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        public SO_WeaponData weaponData;

        protected PlayerAttackState State;
        protected Core.Core Core;


        public virtual void EnterWeapon()
        {
            
        }

        public virtual void ExitWeapon()
        {
            
        }

        public virtual void Attack()
        {
            
        }
        
        public void InitializeWeapon(PlayerAttackState state, Core.Core core)
        {
            Core = core;
            State = state;
        }
       
    }
}