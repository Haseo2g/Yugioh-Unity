using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Fusion
{

    public BaseCard FuseCardList(List<BaseCard> cards)
    {
        while (cards.Count > 1)
        {
            Debug.Log($"Fundindo {cards[0].Name} com {cards[1].Name}");
            BaseCard result = FuseCards(cards[0], cards[1]);

            cards.Insert(0, result);
            
            Debug.Log($"Resultado: {result.Name}");

            cards.RemoveAt(1);
            cards.RemoveAt(1);
        }

        return cards[0];
    }
    
    public BaseCard FuseCards(BaseCard card1, BaseCard card2)
    {
        // Check for fusion
        BaseCard fusedCard = FindFusion(card1, card2);
        if (fusedCard != null)
        {
            return fusedCard;
        }

        // Check for equip
        BaseCard equippedCard = EquipCard(card1, card2);
        if (equippedCard != null)
        {
            return equippedCard;
        }

        #region Check for priority
        // Returns card2 if it's a monster
        if (card2.CardType == CardType.MONSTER)
        {
            return card2;
        }

        // Returns card1 if it's a monster and card2 is not
        if (card1.CardType == CardType.MONSTER)
        {
            return card1;
        }

        // Returns card2 since neither cards are monster type
        return card2;
        #endregion
    }

    public bool CanEquip(BaseCard monster, BaseCard equip)
    {
        // Bright Castle
        if (equip.Id == 668)
        {
            return true;
        }
        string filePath = "Assets\\Editor\\Json\\equips.json";
        TextAsset targetFile = (TextAsset)AssetDatabase.LoadAssetAtPath(filePath, typeof(TextAsset));

        JToken token = JToken.Parse(targetFile.text);
        if (token.Type == JTokenType.Array)
        {
            List<List<int>?> cards = token.ToObject<List<List<int>?>>();
            List<int> equips = cards[monster.Id];
            return equips.Contains(equip.Id);
        }
        else
        {
            List<List<int>?> cards = JsonConvert.DeserializeObject<List<List<int>?>>(targetFile.text);

            List<int> equips = cards.ElementAt(monster.Id).ToList();
            return equips.Contains(equip.Id);
        }
    }

    public BaseCard? EquipCard(BaseCard card1, BaseCard card2)
    {
        if ((card1.CardType != CardType.MONSTER && card2.CardType != CardType.EQUIP) || (card2.CardType != CardType.MONSTER && card1.CardType != CardType.EQUIP))
        {
            MonsterCard monster;
            BaseCard equip;
            if (card1 is MonsterCard)
            {
                monster = (MonsterCard)card1;
                equip = card2;
            }
            else
            {
                monster = (MonsterCard)card2;
                equip = card1;
            }

            // Megamorph
            if (equip.Id == 657)
            {
                monster.Attack += 1000;
                monster.Defense += 1000;
                
                Debug.Log($"Ataque do bichão: {monster.Attack}");
                return monster;
            }    
            
            // Megamorph
            if (CanEquip(monster, equip))
            {
                monster.Attack += 500;
                monster.Defense += 500;
                Debug.Log($"Ataque do bichão: {monster.Attack}");
                return monster;
            }        
        }
        return null;
    }

    public BaseCard? FindFusion(BaseCard card1, BaseCard card2)
    {
        string filePath = "Assets\\Editor\\Json\\fusions.json";

        TextAsset targetFile = (TextAsset)AssetDatabase.LoadAssetAtPath(filePath, typeof(TextAsset));

        List<List<FusionJson>> cards = JsonConvert.DeserializeObject<List<List<FusionJson>>>(targetFile.text);

        List<FusionJson> fusions = cards.ElementAt(card1.Id).ToList();

        foreach (FusionJson fusion in fusions)
        {
            if (card2.Id == fusion.Card)
            {
                return Resources.Load<Card>($"SO/Card/{fusion.Result}");
            }
        }
        return null;
    }
}
