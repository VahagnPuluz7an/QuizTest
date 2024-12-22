using UnityEngine;

namespace Levels
{
    public static class LevelsPrefsData
    {
        public static int CurrentLevelIndex
        {
            get => PlayerPrefs.GetInt("CurrentLevelIndex");
            set => PlayerPrefs.SetInt("CurrentLevelIndex",value);
        }
        
        public static int LastAnswerIndex
        {
            get => PlayerPrefs.GetInt("LastAnswerIndex");
            set => PlayerPrefs.SetInt("LastAnswerIndex",value);
        }
    }
}