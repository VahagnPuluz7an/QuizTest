using UnityEngine;

namespace Levels
{
    public static class LevelsPrefsData
    {
        public static int CurrentLevelIndex
        {
            get => PlayerPrefs.GetInt("CurrentLevelIndex");
            private set => PlayerPrefs.SetInt("CurrentLevelIndex",value);
        }
        
        public static int LastAnswerIndex
        {
            get => PlayerPrefs.GetInt("LastAnswerIndex");
            private set => PlayerPrefs.SetInt("LastAnswerIndex",value);
        }

        public static void ClearLevelData()
        {
            CurrentLevelIndex = 0;
            LastAnswerIndex = -1;
        }

        public static void AddLevelIndex()
        {
            CurrentLevelIndex++;
        }

        public static void UpdateLastAnswer(int index)
        {
            LastAnswerIndex = index;
        }
    }
}