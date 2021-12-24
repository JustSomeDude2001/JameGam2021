using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision
{   
    public string name;
    public string description;
    public string prerequisiteDecision = "";

    public string picture = "";
    
    public int score = 0;

    public ResourceCount[] costs;
    public ResourceCount[] income_modifiers;

    public string getValueString(ResourceCount[] target, string divider = " ", float mult = 1) {
        string res = "";
        for (int i = 0; i < target.GetLength(0); i++) {
            if (target[i].value > 0.00001)
                res += "<sprite name=\"" + GameState.getResourceSkin(target[i].name) + "\">" + (target[i].value * mult).ToString() + divider;
        }

        return res;
    }

    public float getResource(string resource, ResourceCount[] source) {
        foreach (ResourceCount item in source) {
            if (item.name == resource) {
                return item.value;
            }
        }
        return 0;
    }

    public Decision() {

    }
}
