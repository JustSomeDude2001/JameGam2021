using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnactsDecision : MonoBehaviour
{
    public string decision;
    public bool locked = false;

    void notifyFail() {
        Tooltip.currentTooltip = "NOT ENOUGH RESOURCES!!!";
    }
    void notifySuccess() {
        Debug.Log("Enacted decision");
    }

    private void OnMouseDown() {
        if (GameState.canEnact(decision) && !locked) {
            GameState.enactDecision(decision);
            notifySuccess();
            locked = true;

            Destroy(gameObject);
        } else {
            notifyFail();
        }
    }
}
