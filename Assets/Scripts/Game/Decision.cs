using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision
{   
    public string name;
    public string description;
    public string prerequisiteDecision = "";
    
    public int score = 0;

    public ResourceCount[] costs;
    public ResourceCount[] income_modifiers;

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
