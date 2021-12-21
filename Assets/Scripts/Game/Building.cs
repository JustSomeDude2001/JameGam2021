using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Building
{
    public string name = "None";
    public int income_elves;
    public int income_humans;
    public int income_gifts;
    public int income_resources;
    public int income_metals;

    public float offset_security;
    public float offset_logistics;

    [XmlIgnore]
    public string location;
    public Building() {

    }
}
