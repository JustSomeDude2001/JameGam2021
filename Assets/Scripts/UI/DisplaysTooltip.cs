using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysTooltip : MonoBehaviour
{
    TextMeshProUGUI selfText;

    private void Start() {
        selfText = GetComponent<TextMeshProUGUI>();
    }
    
    private void Update() {
        if (Tooltip.visible == true) {
            selfText.text = Tooltip.currentTooltip;
        }
    }
}
