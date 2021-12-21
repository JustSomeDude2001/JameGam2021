using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent
{
    public string name;
    public float security;
    public float logistics;
    
    public List <Building> buildings;

    public Continent(string newName) {
        name = newName;
        buildings = new List<Building>();
    }

    public Continent() {
        buildings = new List<Building>();
    }
}
