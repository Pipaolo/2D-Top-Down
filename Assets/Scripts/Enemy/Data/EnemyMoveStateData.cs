using UnityEngine;

namespace Enemy.Data
{
    [CreateAssetMenu(fileName = "newEnemyMoveStateData", menuName = "Data/Enemy State/Move State")]
    public class EnemyMoveStateData :ScriptableObject
    {
        public float movementSpeed;
    }
}