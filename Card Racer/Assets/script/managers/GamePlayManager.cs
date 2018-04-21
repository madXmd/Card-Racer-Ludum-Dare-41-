using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {


    public static GamePlayManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    float turnTime = 3f;
    int handSize = 3;

    List<Card> cardToKeep = new List<Card>();
    List<Card> cardToUse = new List<Card>();
    List<Card> hand = new List<Card>();



    public void startTheGame()
    {
        foreach (Player player in PlayersManagers.instance.players)
        {
            player.deck.Shuffle();
        }
        UIManeger.instance.keepCard += keepCard;
        UIManeger.instance.castCard += castCard;

        StartCoroutine(Turn());
    }

    Card keepCard(Card card)
    {
        cardToKeep.Add(card);
        cardToUse.RemoveAll( cardToRemove => cardToRemove.getCardNumber()== card.getCardNumber() );
        return card;
    }

    Card castCard(Card card)
    {
        cardToUse.Add(card);

        cardToKeep.RemoveAll(cardToRemove => cardToRemove.getCardNumber() == card.getCardNumber());
        return card;
    }

    IEnumerator Turn()
    {
        while (true)
        {
            Time.timeScale = 0;
            foreach (Player player in PlayersManagers.instance.players)
            {
                if (player.deck.Count < 3)
                {
                    putBackPlayedCards(player);
                }
                hand.Clear();
                cardToUse.Clear();
                cardToKeep.Clear();
                
                for (int i = 0; i < handSize; i++)
                {
                    Card temp = Object.Instantiate(player.deck[i]) as Card;
                    temp.setCardNumber(i);
                    hand.Add(temp);
                }

                player.deck.RemoveRange(0, handSize);
                if (!player.isPc)
                { 
                    //display cards
                    UIManeger.instance.display(hand);

                    //wait until the player choosed cards
                    yield return StartCoroutine(waitForUserChoice());
                        
                    //hide card
                    UIManeger.instance.hide();
                }
                if (player.isPc)
                {
                    int randomCut = Random.Range(0, 2);
                    cardToUse.AddRange(hand.GetRange(0,randomCut));
                    cardToKeep.AddRange(hand.GetRange(randomCut, 2- randomCut));
                }

                foreach (Card card in cardToKeep)
                {
                    player.deck.Insert(0, card);
                }
                foreach (Card card in cardToUse)
                {
                    hand.Remove(card);
                    player.playedCards.Add(card);
                    card.use(player);
                }
            }

            Time.timeScale = 1;
            yield return new WaitForSeconds(turnTime);
        }
    }

    IEnumerator waitForUserChoice()
    {
        while (cardToKeep.Count +cardToUse.Count <3)
            yield return null;
    }

    void putBackPlayedCards(Player player)
    {
        player.deck.AddRange(player.playedCards);
        player.playedCards.Clear();
        player.deck.Shuffle();   
    }


  
}
