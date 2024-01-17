using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainEditor : Editor
{

    [MenuItem("Utilities/Create Cards Json")]
    private static void CreateCards()
    {
       new CreateCard().CardCreator();
    }
}
