using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class CreateCard
{
    public void CardCreator()
    {
        string filePath = "Assets\\Editor\\Json\\Cards.json";

        TextAsset targetFile = (TextAsset)AssetDatabase.LoadAssetAtPath(filePath, typeof(TextAsset));

        List<CardJson> cards = JsonConvert.DeserializeObject<List<CardJson>>(targetFile.text);

        Sprite[] all = Resources.LoadAll<Sprite>("Images/Monsters");

        foreach (var card in cards)
        {
            Card c = CreateCardFromJson(card, all);
            AssetDatabase.CreateAsset(c, $"Assets/Resources/SO/Card/{c.Id}.asset");
        }
        AssetDatabase.SaveAssets();
    }

    private GuardianStar GetStarGuardian(int value)
    {
        return value switch
        {
            1 => GuardianStar.MARS,
            2 => GuardianStar.JUPITER,
            3 => GuardianStar.SATURN,
            4 => GuardianStar.URANUS,
            5 => GuardianStar.PLUTO,
            6 => GuardianStar.NEPTUNE,
            7 => GuardianStar.MERCURY,
            8 => GuardianStar.SUN,
            9 => GuardianStar.MOON,
            _ => GuardianStar.VENUS,
        };
    }

    private MonsterCardType GetMonsterType(int value)
    {
        return value switch
        {
            0 => MonsterCardType.DRAGON,
            1 => MonsterCardType.SPELLCASTER,
            2 => MonsterCardType.ZOMBIE,
            3 => MonsterCardType.WARRIOR,
            4 => MonsterCardType.BEAST_WARRIOR,
            5 => MonsterCardType.BEAST,
            6 => MonsterCardType.WINGED_BEAST,
            7 => MonsterCardType.FIEND,
            8 => MonsterCardType.FAIRY,
            9 => MonsterCardType.INSECT,
            10 => MonsterCardType.DINOSAUR,
            11 => MonsterCardType.REPTILE,
            12 => MonsterCardType.FISH,
            13 => MonsterCardType.SEA_SERPENT,
            14 => MonsterCardType.MACHINE,
            15 => MonsterCardType.THUNDER,
            16 => MonsterCardType.AQUA,
            17 => MonsterCardType.PYRO,
            18 => MonsterCardType.ROCK,
            _ => MonsterCardType.PLANT,
        };
    }
    private CardType GetCardType(int value)
    {
        return value switch
        {
            20 => CardType.MAGIC,
            21 => CardType.TRAP,
            22 => CardType.RITUAL,
            23 => CardType.EQUIP,
            24 => CardType.FIELD,
            _ => CardType.MONSTER
        };
    }

    private Card CreateCardFromJson (CardJson cardJson, Sprite[] all)
    {
        Card card = ScriptableObject.CreateInstance<Card>();
        card.Id = cardJson.Id;
        card.Name = cardJson.Name;
        card.Description = cardJson.Description;
        card.StarchipCost = cardJson.Stars;
        card.Code = cardJson.CardCode;
        card.Sprite = all[cardJson.Id-1];

        if (cardJson.Attack > 0 || cardJson.Defense > 0)
        {
            MonsterCard monsterCard = ScriptableObject.CreateInstance<MonsterCard>();

            monsterCard.Id = card.Id;
            monsterCard.Name = card.Name;
            monsterCard.Description = card.Description;
            monsterCard.StarchipCost = card.StarchipCost;
            monsterCard.Code = card.Code;
            monsterCard.Sprite = card.Sprite;

            monsterCard.Attack = cardJson.Attack;
            monsterCard.Defense = cardJson.Defense;
            monsterCard.GuardianStar1 = GetStarGuardian(cardJson.GuardianStarA);
            monsterCard.GuardianStar2 = GetStarGuardian(cardJson.GuardianStarB);
            monsterCard.MonsterCardType = GetMonsterType(cardJson.Type);
            monsterCard.Level = cardJson.Level;
            monsterCard.CardType = CardType.MONSTER;
            return monsterCard;
        } 
        else
        {
            BackCard backCard = ScriptableObject.CreateInstance<BackCard>();
            backCard.CardType = GetCardType(cardJson.Type);

            backCard.Id = card.Id;
            backCard.Name = card.Name;
            backCard.Description = card.Description;
            backCard.StarchipCost = card.StarchipCost;
            backCard.Code = card.Code;
            backCard.Sprite = card.Sprite;

            return backCard;
        }
    }
}
