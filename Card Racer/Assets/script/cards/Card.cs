using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject {

    public new string name;
    public string description;
    public Sprite pic;

    private int cardNumber;

    public virtual void use(Player player)
    {
        //Debug.Log(name + " used");
    }

    public void setCardNumber(int cardNumber)
    {
        this.cardNumber = cardNumber;
    }

    public  int  getCardNumber()
    {
        return cardNumber ;
    }
}
