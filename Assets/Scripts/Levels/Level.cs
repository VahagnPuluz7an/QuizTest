using System;
using UnityEngine;

namespace Levels
{
    [Serializable]
    public struct Level
    {
        [field: SerializeField] public Vector2Int GridSize { get; private set; }
        [field: SerializeField] public CardData[] Cards { get; private set; }
    }

    [Serializable]
    public struct CardData
    {
        [field: SerializeField] public string Hint { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}