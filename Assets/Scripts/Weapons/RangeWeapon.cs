using System.Collections.Generic;
using ScriptableObjects.Weapons;
using UnityEngine;
using UnityEngine.Pool;

namespace Weapons
{
    public class RangeWeapon : Weapon
    {
        protected ObjectPool<GameObject> BulletPool;
        protected SO_RangeWeaponData RangeWeaponData;

        [SerializeField] protected Transform firePoint;
        [SerializeField] protected List<Transform> firePoints;

        
        private void Awake()
        {
            Setup();
        }

        private void Setup()
        {
            if (weaponData.GetType() == typeof(SO_RangeWeaponData))
            {
                RangeWeaponData = (SO_RangeWeaponData)weaponData;
            }
            else
            {
                Debug.LogError("Wrong data for weapon");
            }
        }
        
        
        public override void EnterWeapon()
        {

            if (RangeWeaponData == null)
            {
                Setup();
            }
            
            BulletPool = new ObjectPool<GameObject>(
                () => Instantiate(RangeWeaponData.projectilePrefab),
                (projectile) =>
                {
                    projectile.SetActive(true);
                },
                (projectile) =>
                {
                    projectile.SetActive(false);
                },
                Destroy, false, 10, 10);
            base.EnterWeapon();
          
        }

        public override void ExitWeapon()
        {
            base.ExitWeapon();
        }
        private void OnDrawGizmos()
        {
            if (firePoint != null)
            {
                Gizmos.DrawWireSphere(firePoint.position, 0.25f);
            }

            if (firePoints is not {Count: > 0}) return;
            
            foreach (var point in firePoints)
            {
                Gizmos.DrawWireSphere(point.position, 0.25f);
            }
        }
    }
}