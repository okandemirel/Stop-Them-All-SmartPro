using System.Collections.Generic;
using Enums;

namespace Data
{
    [System.Serializable]
    public class LevelData
    {
        public int EnemyCount;
        public List<Obstacles> ObstaclesList = new List<Obstacles>();
    }
}