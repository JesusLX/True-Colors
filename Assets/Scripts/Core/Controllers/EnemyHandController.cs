using System.Collections.Generic;
using Assets.Scripts.Core.Turns;
using TrueColors.Data;
using TrueColors.View;
using UnityEngine;

namespace TrueColors.Core.Controller
{
    public class EnemyHandController : MonoBehaviour
    {
        public enum Response
        {
            Default, Good, Neutral, Bad
        }

        public List<GameObject> availableCardPrefabs;
        public List<GameObject> usedCardPrefabs;
        
        public List<Response> deck;

        public Transform dropPosition;
        public GameObject enemyCardPrefab;

        [SerializeField] PlaysController playsController;
        [SerializeField] EnemyTurn enemyTurn;

        public Response GetNextResponse()
        {
            if(deck.Count <= 0)
                return Response.Default;
            
            var response = deck[0];
            deck.RemoveAt(0);
            return response;
        }

        public void LoadDeck()
        {
            
        }

        public void LoadHand()
        {
            
        }

        public void SpawnCard(CardDataModel card)
        {
            var spawnedCard = Instantiate(enemyCardPrefab,dropPosition);
            spawnedCard.transform.SetParent(dropPosition);
            spawnedCard.transform.position = dropPosition.position;
            
            RotateCard(spawnedCard);
            
            var view = spawnedCard.GetComponent<CardView>();
            
            if(view)
                view.Present(card);
            
            spawnedCard.transform.GetChild(1).gameObject.SetActive(false);
            
            playsController.UseCard(card);
            
            enemyTurn.EndTurn();
        }

        void RotateCard(GameObject card)
        {
            var randomRotation = Random.Range(-40f, 40f);
            card.transform.Rotate(new Vector3(0,0,randomRotation));
        }
    }
}