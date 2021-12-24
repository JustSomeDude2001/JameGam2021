using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysScore : MonoBehaviour
{
    TextMeshProUGUI selfText;

    // Start is called before the first frame update
    void Start()
    {
        selfText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        selfText.text = "<sprite name=\"Star\">" + GameState.score;
    }
}
