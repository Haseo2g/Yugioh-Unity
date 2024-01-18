using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duelist
{
    public string Name { get; private set; }
    public int FakeOutChance { get; private set; }
    public int CardsInHand { get; private set; }
    private List<DuelistCard> duelistCards;
    private List<CardDrop> cardDrops;

    public List<DuelistCard> DuelistCards
    {
        get { return duelistCards; }
        set { duelistCards = value; }
    } 

    public List<CardDrop> CardDrops
    {
        get { return cardDrops; }
        set { cardDrops = value; }
    } 
}
