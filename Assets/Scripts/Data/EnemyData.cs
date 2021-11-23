using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class EnemyData
    {
        [Range(0, 10)] public float ForwardMovementSpeed;
    }
}