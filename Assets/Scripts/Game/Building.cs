using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Building
{
    public string name = "None";
    public string description;
    public string prerequisiteDecision = "";
    public string picture = "";
    public int score = 0;

    public ResourceCount[] costs;
    public ResourceCount[] income;

    public string getValueString(ResourceCount[] target, string divider = " ") {
        string res = "";
        for (int i = 0; i < target.GetLength(0); i++) {
            if ((int)target[i].value != 0)
                res += "<sprite name=\"" + GameState.getResourceSkin(target[i].name) + "\">" + target[i].value.ToString() + divider;
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

    public Building() {
        costs = new List<ResourceCount>().ToArray();
        income = new List<ResourceCount>().ToArray();
    }
}
