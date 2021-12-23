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
    public int score = 0;

    public ResourceCount[] costs;
    public ResourceCount[] income;


    public float getResource(string resource, ResourceCount[] source) {
        foreach (ResourceCount item in source) {
            if (item.name == resource) {
                return item.value;
            }
        }
        return 0;
    }

    [XmlIgnore]
    public string location;
    public Building() {
        costs = new List<ResourceCount>().ToArray();
        income = new List<ResourceCount>().ToArray();
    }
}
