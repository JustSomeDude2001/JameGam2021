using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public static bool visible = false;

    public string myTooltip;

    public static string currentTooltip;

    BuildsBuilding builder;
    EnactsDecision decider;


    private void Start() {
        builder = GetComponent<BuildsBuilding>();
        decider = GetComponent<EnactsDecision>();

        currentTooltip = "";

        if (builder != null) {
            myTooltip += builder.buildingType;
            myTooltip += '\n';

            myTooltip += GameState.getBuilding(builder.buildingType).description;
        } else if(decider != null) {
            myTooltip += decider.decision;
            myTooltip += '\n';

            myTooltip += GameState.getDecision(decider.decision).description;
        }
    }

    private void OnMouseOver() {
        visible = true;
    }

    private void OnMouseExit() {
        visible = false;
    }
}
