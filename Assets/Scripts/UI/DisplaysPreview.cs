using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaysPreview : MonoBehaviour
{
    static RawImage selfImage;

    private void Start() {
        selfImage = GetComponent<RawImage>();
    }

    public static void UpdatePreview() {
        selfImage.texture = Tooltip.currentPicture;
    }
}
