using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Core.Controllers;
using TrueColors.Core.Cards;
using TrueColors.Core.Controller;
using TrueColors.Data;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Core.Turns
{
    public class EnemyTurn : MonoBehaviour, ITurn
    {
        [SerializeField] EnemyHandController enemyHandController;
        [SerializeField] PlaysController playsController;
        [SerializeField] PlayerHandController playerHandController;

        [SerializeField] List<ColorDataModelWrapper> allColorsData;
        [SerializeField] List<ShapeDataModelWrapper> allShapesData;
        
        
        #region ITurn Implementation
        public bool JustOnce
        {
            get { return justOnce; }
        }
        
        public UnityEvent OnTurnFinished
        {
            get { return onTurnFinished; }
        }
        
        [SerializeField] bool justOnce;
        UnityEvent onTurnFinished = new UnityEvent();
        #endregion
        
        public void StartTurn()
        {
            StartCoroutine(ThrowCoroutine(2f));
        }

        public void EndTurn()
        {
            OnTurnFinished.Invoke();
        }
        
        #region Coroutines
        IEnumerator ThrowCoroutine(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            ThrowCard();
        }
        #endregion

        void ThrowCard()
        {
            var response = enemyHandController.GetNextResponse();
            if(response == EnemyHandController.Response.Default)
            {
                Debug.Log("No more enemy cards");
                EndTurn();
                return;
            }

            var card = GenerateCard(response);

            enemyHandController.SpawnCard(card);
        }

        CardDataModel GenerateCard(EnemyHandController.Response response)
        {
            var card = new CardDataModel();
            switch(response)
            {
                case EnemyHandController.Response.Good:
                    card = GenerateGoodCard();
                    break;
                
                case EnemyHandController.Response.Neutral:
                    card = GenerateNeutralCard();
                    break;
                case EnemyHandController.Response.Bad:
                    card = GenerateBadCard();
                    break;
                case EnemyHandController.Response.GoodButNotReally:
                    card = GenerateGoodButNotReally();
                    break;
            }

            return card;
        }

        //Respuesta positiva, jugador tiene valida
        CardDataModel GenerateGoodCard()
        {
            var colorData = new ColorDataModelWrapper();
            var shapeData = new ShapeDataModelWrapper();
            
            var lastCard = playsController.GetLastUsedCard();

            if(lastCard.color.Data.type == typeof(RainbowGoodColor))
            {
                var color = lastCard.color.Data;
                var shape = lastCard.shape.Data;

                colorData.SetData(color);
                shapeData.SetData(shape); 
            }
            else
            {

                if(UseSameColor())
                {
                    var color = playerHandController.GetRandomHandColor();
                    var shape = lastCard.shape.Data;

                    colorData.SetData(color);
                    shapeData.SetData(shape);
                }
                else
                {
                    var color = lastCard.color.Data;
                    var shape = playerHandController.GetRandomHandShape();

                    colorData.SetData(color);
                    shapeData.SetData(shape);
                }
            }

            var card = new CardDataModel
            {
                color = colorData,
                shape = shapeData
            };

            return card;
        }

        CardDataModel GenerateGoodButNotReally()
        {
            var colorData = new ColorDataModelWrapper();
            var shapeData = new ShapeDataModelWrapper();
            
            var lastCard = playsController.GetLastUsedCard();

            if(UseSameColor())
            {
                var color = lastCard.color.Data;
                var shape = GenerateBadShape(lastCard.shape.Data, false);
                
                colorData.SetData(color);
                shapeData.SetData(shape);
            }
            else
            {
                var color = GenerateBadColor(lastCard.color.Data, false);
                var shape = lastCard.shape.Data;
                
                colorData.SetData(color);
                shapeData.SetData(shape);
            }
            
            var card = new CardDataModel
            {
                color = colorData,
                shape = shapeData
            };

            return card;
        }

        //Respuesta negativa, jugador tiene valida
        CardDataModel GenerateNeutralCard()
        {
            var colorData = new ColorDataModelWrapper();
            var shapeData = new ShapeDataModelWrapper();
            
            var lastCard = playsController.GetLastUsedCard();

            if(UseSameColor())
            {
                var color = GenerateBadColor(lastCard.color.Data, true);
                var shape = GenerateBadShape(lastCard.shape.Data, false);
                
                colorData.SetData(color);
                shapeData.SetData(shape);
            }
            else
            {
                var color = GenerateBadColor(lastCard.color.Data, false);
                var shape = GenerateBadShape(lastCard.shape.Data, true);
                
                colorData.SetData(color);
                shapeData.SetData(shape);
            }
            
            var card = new CardDataModel
            {
                color = colorData,
                shape = shapeData
            };

            return card;
        }

        //Respuesta negativa, jugador no tiene valida
        CardDataModel GenerateBadCard()
        {
            var colorData = new ColorDataModelWrapper();
            var shapeData = new ShapeDataModelWrapper();
            
            var lastCard = playsController.GetLastUsedCard();
            
            var color = GenerateBadColor(lastCard.color.Data, false);
            var shape = GenerateBadShape(lastCard.shape.Data, false);
                
            colorData.SetData(color);
            shapeData.SetData(shape);

            var card = new CardDataModel
            {
                color = colorData,
                shape = shapeData
            };

            return card;
        }

        #region Support Methods
        bool UseSameColor()
        {
            var random = Random.Range(0, 2);

            return random == 0;
        }
        #endregion
        
        #region Support Card Generation
        ColorDataModel GenerateBadColor(ColorDataModel usedColor, bool playerMustHave)
        {
            var allHandColors = playerHandController.GetAllHandColor();

            foreach(var wrapper in allColorsData.Where(wrapper => wrapper.Data.type != usedColor.type))
            {
                //Color distinto al usado
                if(playerMustHave)
                {
                    //Player tiene respuesta
                    if(allHandColors.Any(color => color.type == wrapper.Data.type))
                    {
                        return wrapper.Data;
                    }
                }
                else
                {
                    //Player no tiene respuesta
                    if(allHandColors.All(color => color.type != wrapper.Data.type))
                    {
                        return wrapper.Data;
                    }
                }
            }

            Debug.Log("Generando Carta mala - no color");
            return null;
        }

        ShapeDataModel GenerateBadShape(ShapeDataModel usedShape, bool playerMustHave)
        {
            var allHandShapes = playerHandController.GetAllHandShapes();

            foreach(var wrapper in allShapesData.Where(wrapper => wrapper.Data.type != usedShape.type))
            {
                //Color distinto al usado
                if(playerMustHave)
                {
                    //Player tiene respuesta
                    if(allHandShapes.Any(shape => shape.type == wrapper.Data.type))
                    {
                        return wrapper.Data;
                    }
                }
                else
                {
                    //Player no tiene respuesta
                    if(allHandShapes.All(shape => shape.type != wrapper.Data.type))
                    {
                        return wrapper.Data;
                    }
                }
            }

            Debug.Log("Generando Carta mala - no shape");
            return null;
        }
        #endregion
    }
}