using System;
using Assets.Scripts.Core.Cards;
using UnityEngine;

namespace TrueColors.Data
{
    [Serializable]
    public class ShapeDataModel
    {
        public Sprite artwork;
        [ClassImplements(typeof(ICardShape))] public ClassTypeReference type;
    }
}