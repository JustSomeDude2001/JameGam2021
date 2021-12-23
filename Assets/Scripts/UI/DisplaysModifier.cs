using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaysModifier : MonoBehaviour
{
    Text selfText;

    public string resource;

    // Start is called before the first frame update
    void Start()
    {
        selfText = GetComponent<Text>();
    }

    void Update()
    {
        selfText.text = ((int)(GameState.getModifier(resource) * 100)).ToString() + '%';
    }
}
