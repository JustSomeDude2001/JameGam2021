using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private void Start() {
        int type = Random.Range(0, 100);

        if (type == 99) {

        }    
    
        if (type < 70 || !GameState.canEnactAny()) {
            BuildsBuilding builder = gameObject.AddComponent<BuildsBuilding>();
            builder.buildingType = GameState.getRandomPossibleBuilding();
        } else {
            EnactsDecision decider = gameObject.AddComponent<EnactsDecision>();
            decider.decision = GameState.getRandomPossibleDecision();
        }
    }
}
