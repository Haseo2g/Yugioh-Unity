using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestFusion : MonoBehaviour
{
    void Start()
    {
        Card td = Resources.Load<Card>($"SO/Card/425");
        Debug.Log($"Fundir {td.Name} com {td.Name} resulta em {new Fusion().FuseCards(td, td).Name}");

/*        System.Random random = new System.Random();*/

/*        for (int i = 0; i < 10; i++)
        {
            Card card1 = Resources.Load<Card>($"SO/Card/{random.Next(1, 723)}");
            Card card2 = Resources.Load<Card>($"SO/Card/{random.Next(1, 723)}");

            Card result = new Fusion().FuseCards(card1, card2);

            Debug.Log($"Fundir {card1.Name} com {card2.Name} resulta em {result.Name}");
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}
