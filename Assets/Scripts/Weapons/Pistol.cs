using System;
using ScriptableObjects.Weapons;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace Weapons
{
    public class Pistol : RangeWeapon
    {
        
        public override void Attack()
        {
            base.Attack();
            foreach (var point in firePoints)
            {
                var position = point.position;
                var projectileGameObject = BulletPool.Get();
                var projectileScript = projectileGameObject.GetComponent<Projectile>();
                projectileGameObject.transform.SetPositionAndRotation(position, point.rotation);

                projectileScript.FireProjectile(
                    (projectile) => Hit(projectileGameObject, projectile),
                    point.up,
                    RangeWeaponData.bulletSpeed, 
                    RangeWeaponData.damage
                    );
            }
       
        }

        private void Hit( GameObject projectileGameObject, Projectile projectile)
        {   
            BulletPool.Release(projectileGameObject);
        }
    }
}