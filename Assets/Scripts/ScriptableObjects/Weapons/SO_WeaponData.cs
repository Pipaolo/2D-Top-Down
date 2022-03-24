using UnityEngine;

namespace ScriptableObjects.Weapons
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapons/Base Data")]
    public class SO_WeaponData : ScriptableObject
    {
        public float damage;
    }
}