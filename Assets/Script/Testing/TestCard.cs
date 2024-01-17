using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TestCard : MonoBehaviour
{
    [SerializeField]
    public Card card;
    public Image image;
    public TextMeshProUGUI cardType;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardDescription;
    public TextMeshProUGUI cardCode;
    public TextMeshProUGUI cardNumber;
    public TextMeshProUGUI cardAttack;
    public TextMeshProUGUI cardDefense;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = card.Sprite;
        cardName.text= $"{card.Id} - {card.Name}";
        cardDescription.text= card.Description;
        cardCode.text = card.Code;
    }
}
