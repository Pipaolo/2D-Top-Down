using Interfaces;
using ScriptableObjects.Weapons;
using UnityEngine;
using UnityEngine.Pool;

namespace Weapons
{
    public class Shotgun : RangeWeapon
    {
        



        public override void Attack()
        {
            base.Attack();
            
            for (int i = 0; i < RangeWeaponData.bulletCount; i++)
            {
                var bulletSpread = RangeWeaponData.bulletSpread;
                // Randomize bullet spread
                var randomX = Random.Range(-bulletSpread, bulletSpread);
                var randomY = Random.Range(-bulletSpread, bulletSpread);
                var randomZ = Random.Range(-bulletSpread, bulletSpread);
                
                var projectileGameObject = BulletPool.Get();
                var projectileScript = projectileGameObject.GetComponent<Projectile>();

                var randomDir = firePoint.up + new Vector3(randomX, randomY, randomZ);
                projectileGameObject.transform.SetPositionAndRotation(firePoint.position , firePoint.rotation);

                projectileScript.FireProjectile(
                    (projectile) => Hit(projectileGameObject, projectile),
                    randomDir,
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