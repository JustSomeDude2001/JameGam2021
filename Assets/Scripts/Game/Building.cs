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


    public string prerequisiteDecision;

    [XmlIgnore]
    public string location;
    public Building() {

    }
}
