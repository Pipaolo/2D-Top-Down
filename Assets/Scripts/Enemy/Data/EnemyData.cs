using UnityEngine;

namespace Enemy.Data
{
    [CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
    public class EnemyData: ScriptableObject
    {
        public float maxHealth = 100f;
        public float movementSpeed = 1f;
    }
}