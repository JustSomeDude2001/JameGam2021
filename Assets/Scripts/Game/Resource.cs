using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCount {
    public string name;
    public float value;

    public ResourceCount(string name, float value) {
        this.name = name;
        this.value = value;
    }

    public ResourceCount() {

    }
}

public class Resource
{
    public string name;
    public string description;
    public float baseValue;

    public ResourceCount getBase() {
        return new ResourceCount(name, baseValue);
    }

    public ResourceCount getZero() {
        return new ResourceCount(name, 0);
    }

    public Resource() {
        
    }
}
