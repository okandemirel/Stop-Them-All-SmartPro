using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Stop Them All-SmartPro/Player Data", order = 0)]
    public class PlayerScriptable : ScriptableObject
    {
        public PlayerData Data;
    }
}