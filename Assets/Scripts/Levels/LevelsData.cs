using UnityEngine;

namespace Levels
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "ScriptableObjects/Levels/LevelsData")]
    public class LevelsData : ScriptableObject
    {
        [field: SerializeField] public Card CardPrefab { get; private set; }
        [field: SerializeField] public Level[] Levels { get; private set; }
        
        public Level CurrentLevel => Levels[LevelsPrefsData.CurrentLevelIndex];
        public bool LevelsEnded => LevelsPrefsData.CurrentLevelIndex >= Levels.Length;
    }
}
