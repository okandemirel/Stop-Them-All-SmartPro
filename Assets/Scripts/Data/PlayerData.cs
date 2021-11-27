using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        [Range(0, 10)] public float ForwardMovementSpeed;
    }
}