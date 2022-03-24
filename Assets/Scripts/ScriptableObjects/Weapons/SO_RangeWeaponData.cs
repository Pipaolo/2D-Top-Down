using UnityEngine;

namespace ScriptableObjects.Weapons
{    
    [CreateAssetMenu(fileName = "newRangeWeaponData", menuName = "Data/Weapons/Range Weapon")]
    public class SO_RangeWeaponData : SO_WeaponData
    {
        [SerializeField] public GameObject projectilePrefab;
        public float bulletSpeed;
        public float bulletSpread;

        public float shootingSpeed;
        public float bulletCount = 1;
    }
}