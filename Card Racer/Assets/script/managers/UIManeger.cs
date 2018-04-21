using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManeger : MonoBehaviour {

    public static UIManeger instance { get; private set; }
    public GameObject handParent;

    public delegate Card CastCard(Card hand);
    public delegate Card KeepCard(Card hand);
    public CastCard castCard;
    public KeepCard keepCard;

    public List<Vector3> defaultPosForCards;

    float localY = -100f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            defaultPosForCards = new List<Vector3>();
            foreach (Transform child in handParent.transform)
            {
                defaultPosForCards.Add(child.GetComponent<RectTransform>().localPosition);
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void display(List<Card> hand)
    {
        int i = 0;
        foreach (Transform child in handParent.transform)
        {
            Transform temp = child;
            CardUI tempUi = child.gameObject.GetComponent<CardUI>();
            tempUi.setCard(hand[i]);
            temp.GetComponent<RectTransform>().localPosition = defaultPosForCards[i];
            i++;

        }
        handParent.SetActive(true);
    }

    public void hide()
    {
        handParent.SetActive(false);
    }

    public void startTheGame()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        GamePlayManager.instance.startTheGame();
        button.SetActive(false);
    }

    public void cardClicked()
    {
       GameObject cardUi = EventSystem.current.currentSelectedGameObject;
        cardUi.gameObject.SetActive(false);
    }

    public void keepTheCard()
    {
        GameObject cardUi = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        RectTransform rect = cardUi.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(rect.localPosition.x, localY - 50, rect.localPosition.z);
        if(keepCard !=null)
            keepCard(getCardFromCardUI(cardUi));
    }

    Card getCardFromCardUI(GameObject cardUi)
    {
       return cardUi.GetComponent<CardUI>().getCard();
    }

    public void useTheCard()
    {
        GameObject cardUi = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        RectTransform rect = cardUi.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(rect.localPosition.x, localY + 50, rect.localPosition.z);
        if(castCard !=null)
            castCard(getCardFromCardUI(cardUi));
    }
}
