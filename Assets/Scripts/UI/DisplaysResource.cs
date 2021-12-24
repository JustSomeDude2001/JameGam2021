using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysResource : MonoBehaviour
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
            selfText.text += "<sprite name=\"" + GameState.resourcesDescs[i].skin + "\"> ";
            selfText.text += ((int)GameState.resources[i].value).ToString() + '\n';    
        }   
    }
}
