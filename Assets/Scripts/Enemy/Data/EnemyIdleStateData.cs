using UnityEngine;

namespace Enemy.Data
{
    [CreateAssetMenu(fileName = "newEnemyIdleStateData", menuName = "Data/Enemy State/Idle State")]
    public class EnemyIdleStateData: ScriptableObject
    {
        public float minIdleTime = 1f;
        public float maxIdleTime = 2f;

    }
}