using System;

namespace TrueColors.Core.Cards
{
    public class Card : ICard
    {
        public ICardShape shape { get; }
        public ICardColor color { get; }

        public Card(ICardShape shape, ICardColor color)
        {
            this.shape = shape;
            this.color = color;
        }
        
        public bool IsMatch(ICard card)
        {
            if(color.GetType() == typeof(RainbowGoodColor))
                return true;
            
            return card.color.GetType() == color.GetType() || card.shape.GetType() == shape.GetType();
        }
    }
}