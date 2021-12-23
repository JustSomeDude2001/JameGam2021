using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplaysResource : MonoBehaviour
{
    TextMeshProUGUI selfText;

    public string resource;

    // Start is called before the first frame update
    void Start()
    {
        selfText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        selfText.text = "<sprite name=\"" + GameState.getResourceSkin(resource) + "\"> ";
        selfText.text += GameState.getResource(resource).ToString();
    }
}
