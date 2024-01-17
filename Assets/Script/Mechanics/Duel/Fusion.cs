using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Fusion
{
    public Card FuseCards(Card card1, Card card2)
    {
        Card fusedCard = FindFusion(card1, card2);
        if (fusedCard != null)
        {
            return fusedCard;
        }

        if (card1.CardType == CardType.MONSTER)
        {
        }

        if (card1.CardType != CardType.MONSTER && card2.CardType != CardType.MONSTER)
        {
            return card2;
        }
        return null;
    }

    public bool CanEquip(Card card1, Card card2)
    {
        // Bright Castle
        if (card2.Id == 668)
        {
            return true;
        }
        return false;
    }

    public Card EquipCard(Card card1, Card card2)
    {
        if (card2 == null)
        {
            return card1;
        }

        if ((card1.CardType != CardType.MONSTER && card2.CardType != CardType.EQUIP) || (card2.CardType != CardType.MONSTER && card1.CardType != CardType.EQUIP))
        {
            return card2;
        }
        if (card1.CardType != CardType.MONSTER)
        {
            (card2, card1) = (card1, card2);
        }

        // Megamorph
        if (card2.Id == 657)
        {
            ((MonsterCard)card1).Attack += 1000;
            ((MonsterCard)card1).Defense += 1000;
        }

        if (CanEquip(card1, card2))
        {
            ((MonsterCard)card1).Attack += 500;
            ((MonsterCard)card1).Defense += 500;
        }
        return card1;
    }

    public Card FindFusion(Card card1, Card card2)
    {
        string filePath = "Assets\\Editor\\Json\\fusions.json";

        TextAsset targetFile = (TextAsset)AssetDatabase.LoadAssetAtPath(filePath, typeof(TextAsset));

        Debug.Log(targetFile.text);

        List<List<FusionJson>> cards = JsonConvert.DeserializeObject<List<List<FusionJson>>>(targetFile.text);

        Debug.Log(cards.Count);

        List<FusionJson> fusions = cards.ElementAt(card1.Id).ToList();

        foreach (FusionJson fusion in fusions)
        {
            if (card2.Id == fusion.Card)
            {
                return Resources.Load<Card>($"SO/Card/{fusion.Result}");
            }
        }
        return card2;
    }
}
