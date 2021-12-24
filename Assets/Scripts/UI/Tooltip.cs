using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public static bool visible = false;

    public string myTooltip;

    public static string currentTooltip;
    public static Texture2D currentPicture;

    public Texture2D myPicture;

    BuildsBuilding builder;
    EnactsDecision decider;


    private void Start() {
        builder = GetComponent<BuildsBuilding>();
        decider = GetComponent<EnactsDecision>();

        currentTooltip = "";

        if (builder != null) {
            Building target = GameState.getBuilding(builder.buildingType);

            myTooltip += target.name;
            myTooltip += "\n\n";

            myTooltip += target.description;

            myTooltip += "\n\nCOSTS:\n";
            myTooltip += target.getValueString(target.costs, " ");

            myTooltip += "\nPRODUCES\n";
            myTooltip += target.getValueString(target.income, " ");
        
            myPicture = Resources.Load<Texture2D>(target.picture);

            if (target.score > 0.00001) {
                myTooltip += "\n\n<sprite name=\"Star\">" + target.score;
            }
        } else if(decider != null) {
            Decision target = GameState.getDecision(decider.decision);
            
            myTooltip += target.name;
            myTooltip += "\n\n";

            myTooltip += target.description;

            myTooltip += "\n\nCOSTS:\n";
            myTooltip += target.getValueString(target.costs, " ");

            myTooltip += "\nINCREASES OUTPUTS BY:\n";
            myTooltip += target.getValueString(target.income_modifiers, "% ", 100);
        
            myPicture = Resources.Load<Texture2D>(target.picture);
            if (target.score > 0.00001) {
                myTooltip += "\n\n<sprite name=\"Star\">" + target.score;
            };
        }
    }

    private void OnMouseEnter() {
        visible = true;
        currentTooltip = myTooltip;
        currentPicture = myPicture;
        DisplaysPreview.UpdatePreview();
    }

    private void OnMouseExit() {
        visible = false;
    }
}
