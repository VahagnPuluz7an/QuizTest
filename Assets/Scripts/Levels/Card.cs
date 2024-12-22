using System;
using DG.Tweening;
using UnityEngine;

namespace Levels
{
    public class Card : MonoBehaviour
    {
        public static event Action RightCardChoosen;
        
        [SerializeField] private SpriteRenderer mainSpriteRenderer;
        [SerializeField] private SpriteRenderer back;
        [SerializeField] private SpriteRenderer outline;
        [SerializeField] private float bounceDuration;
        [SerializeField] private float wrongAnimationStrength;
        [SerializeField] private float rightAnimationStrength;

        public int Index { get; private set; }

        public void Init(int index)
        {
            Index = index;
        }
        
        public Vector2 GetCardSize()
        {
            var backScale = back.transform.localScale;
            var outlineScale = outline.transform.localScale;
            
            float x = back.sprite.bounds.size.x * backScale.x * outlineScale.x;
            float y = back.sprite.bounds.size.y * backScale.y * outlineScale.y;

            return new Vector2(x, y);
        }
        
        public void ChangeSprite(Sprite sprite)
        {
            var rotation = sprite.rect.size.x < sprite.rect.size.y * 1.4f ? Vector3.zero : new Vector3(0,0,270);
            mainSpriteRenderer.sprite = sprite;
            mainSpriteRenderer.transform.eulerAngles = rotation;
        }

        public void DoBounceEffect()
        {
            var startScale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(startScale, bounceDuration).SetEase(Ease.OutBounce);
        }

        public bool CheckRightCard(bool animate = true)
        {
            bool rightCard = LevelsPrefsData.LastAnswerIndex == Index;
            
            if(rightCard)
                RightCardChoosen?.Invoke();
            
            if (!animate)
                return rightCard;

            if(rightCard)
                RightAnimation();
            else
                WrongAnimation();
            
            return rightCard;
        }
        
        private void RightAnimation()
        {
            var startScale = mainSpriteRenderer.transform.localScale;
            mainSpriteRenderer.transform.localScale = Vector3.one * rightAnimationStrength;
            mainSpriteRenderer.transform.DOScale(startScale, bounceDuration).SetEase(Ease.OutBounce);
        }
        
        private void WrongAnimation()
        {
            mainSpriteRenderer.transform.DOComplete();
            mainSpriteRenderer.transform.DOShakePosition(0.5f, Vector3.right * wrongAnimationStrength).SetEase(Ease.InBounce);
        }
    }
}