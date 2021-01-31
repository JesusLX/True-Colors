using TrueColors.Core.Controller;
using TrueColors.Core.Turn;
using UnityEngine;

namespace Assets.Scripts.Core.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] PlayerHandController playerHandController;
        [SerializeField] EnemyHandController enemyHandController;
        [SerializeField] TurnBehaviour turnBehaviour;

        void Start()
        {
            playerHandController.Init();
            
            enemyHandController.LoadDeck();
            enemyHandController.LoadHand();
            
            turnBehaviour.LaunchFirstTurn();
        }
    }
}