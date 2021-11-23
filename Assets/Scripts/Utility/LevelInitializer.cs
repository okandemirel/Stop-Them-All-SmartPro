using UnityEngine;

namespace Utility
{
    public class LevelInitializer : MonoBehaviour
    {
        private void Start()
        {
            LevelManager.Instance.onInitializeLevel += OnInitializeLevel;
        }

        private void OnDisable()
        {
            LevelManager.Instance.onInitializeLevel -= OnInitializeLevel;
        }


        private void OnInitializeLevel(int levelValue)
        {
            GameObject newLevel = Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level {levelValue}");

            Instantiate(newLevel, GameObject.Find("LevelHolder").transform);
        }
    }
}