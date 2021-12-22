using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Building
{
    public string name = "None";

    public ResourceCount[] costs;
    public ResourceCount[] income;
    public ResourceCount[] maint;


    public float getResource(string resource, ResourceCount[] source) {
        foreach (ResourceCount item in source) {
            if (item.name == resource) {
                return item.value;
            }
        }
        return 0;
    }

    public string prerequisiteDecision;

    [XmlIgnore]
    public string location;
    public Building() {
        costs = new List<ResourceCount>().ToArray();
        income = new List<ResourceCount>().ToArray();
        maint = new List<ResourceCount>().ToArray();
    }
}
