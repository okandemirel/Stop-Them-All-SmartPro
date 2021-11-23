using System.Collections.Generic;
using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level Data", menuName = "Stop Them All-SmartPro/Level Data", order = 0)]
    public class LevelScriptable : ScriptableObject
    {
        public List<LevelData> LevelData = new List<LevelData>();
    }
}