using UnityEngine;

namespace Utility
{
    public class LevelDestroyer : MonoBehaviour
    {
        private void Start()
        {
            LevelManager.Instance.onClearActiveLevel += OnClearActiveLevel;
        }

        private void OnDisable()
        {
            LevelManager.Instance.onClearActiveLevel -= OnClearActiveLevel;
        }

        private void OnClearActiveLevel()
        {
            var levelHolder = GameObject.Find("LevelHolder").gameObject;

            Destroy(levelHolder.transform.GetChild(0).gameObject);
        }
    }
}