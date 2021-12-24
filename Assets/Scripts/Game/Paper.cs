using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public static bool hadDecisionOnBoard = false;

    private void Start() {
        int type = Random.Range(0, 100);
    
        if (type < 80 || !GameState.canEnactAny() || hadDecisionOnBoard == true) {
            BuildsBuilding builder = gameObject.AddComponent<BuildsBuilding>();
            builder.buildingType = GameState.getRandomPossibleBuilding();
        } else {
            EnactsDecision decider = gameObject.AddComponent<EnactsDecision>();
            decider.decision = GameState.getRandomPossibleDecision();
            hadDecisionOnBoard = true;
        }
    }
}
