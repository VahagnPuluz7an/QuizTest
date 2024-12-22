using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Levels
{
    public class HintText : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void UpdateHint(string hint, bool animate)
        {
            text.SetText($"Find {hint}");
            
            if (!animate)
                return;
            var startColor = text.color;
            text.color = new Color(startColor.r, startColor.g, startColor.b, 0);
            text.DOColor(startColor, 1f);
        }
    }
}