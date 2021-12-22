using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnactsDecision : MonoBehaviour
{
    public string decision;

    void notifyFail() {

    }
    void notifySuccess() {

    }

    private void OnMouseDown() {
        if (GameState.canEnact(decision)) {
            GameState.enactDecision(decision);
            notifySuccess();
        } else {
            notifyFail();
        }
    }
}
