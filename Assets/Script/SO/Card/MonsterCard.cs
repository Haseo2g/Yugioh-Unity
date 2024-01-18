using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterCard : Card
{
    [SerializeField]
    private int attack;

    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    [SerializeField]
    private int defense;

    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }

    [SerializeField]
    private MonsterCardType monsterCardType;

    public MonsterCardType MonsterCardType
    {
        get { return monsterCardType; }
        set { monsterCardType = value; }
    }

    [SerializeField]
    private int level;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    [SerializeField]
    private GuardianStar guardianStar1;

    public GuardianStar GuardianStar1
    {
        get { return guardianStar1; }
        set { guardianStar1 = value; }
    }

    [SerializeField]
    private GuardianStar guardianStar2;

    public GuardianStar GuardianStar2
    {
        get { return guardianStar2; }
        set { guardianStar2 = value; }
    }
}
