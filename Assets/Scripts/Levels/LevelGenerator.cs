using System;
using System.Linq;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Levels
{
    public class LevelGenerator : IInitializable
    {
        public static event Action LevelsEnded;
        
        [Inject] private LevelsData _levelsData;
        [Inject] private HintText _hintText;

        private GameObject _cardsParent;
        
        public void Initialize()
        {
            if (_levelsData.LevelsEnded)
            {
                LevelsPrefsData.ClearLevelData();
            }
            SpawnLevel(true);
        }
        
        public void NextLevel()
        {
            LevelsPrefsData.AddLevelIndex();

            if (_levelsData.LevelsEnded)
            {
                LevelsEnded?.Invoke();
                return;
            }
            
            Object.Destroy(_cardsParent);
            SpawnLevel(false);
        }

        public void RestartLevel()
        {
            Object.Destroy(_cardsParent);
            SpawnLevel(true);
        }
        
        private void SpawnLevel(bool animate)
        {
            var currentLevel = _levelsData.CurrentLevel;
            var answer = GetRandomAnswer(currentLevel);
            
            int spriteCounter = 0;
            _cardsParent = new GameObject($"Level {LevelsPrefsData.CurrentLevelIndex}");
            
            for (int row = 0; row < currentLevel.GridSize.x; row++)
            {
                for (int column = 0; column < currentLevel.GridSize.y; column++)
                {
                    var newCard = Object.Instantiate(_levelsData.CardPrefab, _cardsParent.transform);

                    var cardSize = newCard.GetCardSize();
                    
                    newCard.transform.position = Vector3.Scale(cardSize, new Vector3(row, column));
                    
                    var currentLevelCard = currentLevel.Cards[spriteCounter];
                    
                    newCard.Init(spriteCounter);
                    newCard.ChangeSprite(currentLevelCard.Sprite);
                    
                    if(animate)
                        newCard.DoBounceEffect();
                    
                    spriteCounter++;
                }
            }

            var center = _cardsParent.transform.Cast<Transform>().Aggregate(Vector3.zero, (current, t) => current + t.position);
            center /= _cardsParent.transform.childCount;

            _cardsParent.transform.position -= center;
            
            _hintText.UpdateHint(answer.Hint, animate);
        }
                
        private static CardData GetRandomAnswer(Level currentLevel)
        {
            int randomIndex = Random.Range(0, currentLevel.Cards.Length);
            
            while(randomIndex == LevelsPrefsData.LastAnswerIndex)
                randomIndex = Random.Range(0, currentLevel.Cards.Length);

            LevelsPrefsData.UpdateLastAnswer(randomIndex);
            return currentLevel.Cards[randomIndex];
        }
    }
}
