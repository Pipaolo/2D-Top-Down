using UnityEngine;

namespace Weapons
{
    public class Sniper : RangeWeapon
    {
        public override void Attack()
        {
            base.Attack();
    
            var projectileGameObject = BulletPool.Get();
            var projectileScript = projectileGameObject.GetComponent<Projectile>();

            projectileGameObject.transform.SetPositionAndRotation(firePoint.position , firePoint.rotation);

            projectileScript.FireProjectile(
                (projectile) => Hit(projectileGameObject, projectile),
                firePoint.up,
                RangeWeaponData.bulletSpeed, 
                RangeWeaponData.damage
            );
        }


        private void Hit( GameObject projectileGameObject, Projectile projectile)
        {   
            BulletPool.Release(projectileGameObject);
        }
    }
}
