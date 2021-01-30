namespace TrueColors.Core.Cards
{
    public interface ICard
    {
        ICardShape shape { get; }
        ICardColor color { get; }

        bool IsMatch(ICard card);
    }
}