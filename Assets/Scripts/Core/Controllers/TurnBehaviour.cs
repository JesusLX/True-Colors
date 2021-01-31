using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Core.Turns;
using TrueColors.Core.Controller;
using UnityEngine;

namespace TrueColors.Core.Turn
{
    public class TurnBehaviour : MonoBehaviour
    {
        public List<GameObject> turnList;
        public GameObject rainbowTurn;

        TurnController turnController;
        public TurnController TurnController => turnController;
        public void Init()
        {
            turnController = new TurnController(turnList.Select(turn => turn.GetComponent<ITurn>()).ToList());
            
            TrySetBadRainbow();
        }

        [ContextMenu("TryTurns")]
        public void LaunchFirstTurn()
        {
            Init();
            turnController.LaunchFirstTurn();
        }

        void TrySetBadRainbow()
        {
            var badRainbow = rainbowTurn.GetComponent<ITurn>();
            if(badRainbow!=null)
                turnController.SetBadRainbowTurn(badRainbow);
        }
    }
}