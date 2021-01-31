using UnityEngine.Events;

namespace Assets.Scripts.Core.Turns
{
    public interface ITurn
    {
        bool JustOnce { get; }
        UnityEvent OnTurnFinished { get; }

        void StartTurn();
        void EndTurn();
    }
}