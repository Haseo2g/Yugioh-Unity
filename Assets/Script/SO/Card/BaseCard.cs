using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCard : ScriptableObject
{

    [SerializeField]
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    [SerializeField]
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    [SerializeField]
    private Sprite sprite;

    public Sprite Sprite
    {
        get { return sprite; }
        set { sprite = value; }
    }

    [SerializeField]
    private CardType cardType;

    public CardType CardType
    {
        get { return cardType; }
        set { cardType = value; }
    }

    [SerializeField]
    private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    [SerializeField]
    private int starchipCost;

    public int StarchipCost
    {
        get { return starchipCost; }
        set { starchipCost = value; }
    }

    [SerializeField]
    private string code;

    public string Code
    {
        get { return code; }
        set { code = value; }
    }
}
