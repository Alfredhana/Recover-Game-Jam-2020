using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public Card(int cardType)
    {
        this.cardType = cardType;
    }
    int cardType;
    public int Use()
    {
        return cardType;
    }
}
