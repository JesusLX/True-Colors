using System;
using Assets.Scripts.Core.Cards;
using UnityEngine;

namespace TrueColors.Data
{
    [Serializable]
    public class ColorDataModel
    {
        public Gradient color;
        [ClassImplements(typeof(ICardColor))] public ClassTypeReference type;
    }
}