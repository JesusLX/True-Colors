using System.Collections;
using TrueColors.Core.Controller;
using TrueColors.Core.Turn;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Core.Controllers {
    public class GameController : MonoBehaviour {
        public static GameController Instance { get; private set; }
        private void Awake() {
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
            }
        }

        public int nextScene;

        [SerializeField] PlayerHandController playerHandController;
        [SerializeField] EnemyHandController enemyHandController;
        [SerializeField] TurnBehaviour turnBehaviour;

        void Start() {
            FadeOutController.Instance.FadeIn();
            playerHandController.Init();

            enemyHandController.LoadDeck();
            enemyHandController.LoadHand();

            turnBehaviour.LaunchFirstTurn();
        }

        public void GoNextScene() {
            StartCoroutine(WaitSeconds());
        }

        IEnumerator WaitSeconds() {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(nextScene);
        }
    }
}