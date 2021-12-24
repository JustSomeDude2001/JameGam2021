using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysModifier : MonoBehaviour
{
    TextMeshProUGUI selfText;

    // Start is called before the first frame update
    void Start()
    {
        selfText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        selfText.text = "";
        for (int i = 0; i < GameState.resources.Count; i++) {
            selfText.text += ((int)(GameState.income_modifiers[i] * 100)).ToString() + "%\n";    
        }   
    }
}
