using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {

    public new Text name;
    public Text description;
    public Image pic;

    Card card;

    public void setCard(Card card)
    {
        this.card = card;
        name.text = card.name;
        description.text = card.description;
        pic.sprite = card.pic;
    }

    public Card getCard()
    {
        return card;
    }

}
