using System.Collections.Generic;
using Assets.Scripts.Core.Turns;
using UnityEngine;
using UnityEngine.Events;

namespace TrueColors.Core.Controller
{
    public class TurnController
    {
        List<ITurn> turnList;
        int currentTurnIndex;

        ITurn badRainbowTurn;

        public TurnController(List<ITurn> turnList)
        {
            currentTurnIndex = 0;
            this.turnList = turnList;
            
            Init();
        }
        
        void Init()
        {
            AddEndTurnListeners();
        }

       public void LaunchFirstTurn()
        {
            if(turnList.Count == 0)
                return;
            
            turnList[0].StartTurn();
        }

        void LaunchTurn()
        {
            if(turnList.Count == 0)
                return;
            
            turnList[currentTurnIndex].StartTurn();
        }

        void LaunchTurn(int index)
        {
            if(turnList.Count == 0)
                return;
            
            turnList[index].StartTurn();
        }

        void AddEndTurnListeners()
        {
            Debug.Log($"Adding turn listeners - size {turnList.Count}");
            foreach(var turn in turnList)
            {
                turn.OnTurnFinished.AddListener(NextTurn);
            }
        }

        void NextTurn()
        {
            Debug.Log("Next turn");
            if(turnList[currentTurnIndex].JustOnce)
                RemoveTurn();
            
            var totalTurns = turnList.Count;
            var placeHolderNextTurn = currentTurnIndex +1 ;
            
            Debug.Log($"Total turns - {totalTurns} || Placeholder - {placeHolderNextTurn}");
            currentTurnIndex = placeHolderNextTurn >= totalTurns ? 0 : placeHolderNextTurn;
            
            Debug.Log($"New turn - {currentTurnIndex}");
            
            LaunchTurn();
        }

        void RemoveTurn()
        {
            Debug.Log("Removing turn");
            turnList[currentTurnIndex].OnTurnFinished.RemoveListener(NextTurn);
            turnList.RemoveAt(currentTurnIndex);
            currentTurnIndex -= 1;
        }

        public void LaunchRainbowTurn()
        {
            badRainbowTurn.StartTurn();
        }

        public void SetBadRainbowTurn(ITurn rainbowturn)
        {
            badRainbowTurn = rainbowturn;
        }
    }
}