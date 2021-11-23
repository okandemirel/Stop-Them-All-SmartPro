using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Stop Them All-SmartPro/Enemy Data", order = 0)]
    public class EnemyScriptable : ScriptableObject
    {
        public EnemyData EnemyData;
    }
}