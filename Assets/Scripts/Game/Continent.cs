using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continent
{
    public string name;
    public List <int> buildings;

    public float unrest = 0;

    public float getIncome(string resource) {
        float result = 0;
        for (int i = 0; i < buildings.Count; i++) {
            result += GameState.buildings[i].getResource(resource, GameState.buildings[i].income);
        }
        return result * (1f - unrest);
    }

    public float getMaint(string resource) {
        float result = 0;
        for (int i = 0; i < buildings.Count; i++) {
            result += GameState.buildings[i].getResource(resource, GameState.buildings[i].maint);
        }
        return result * (1f + unrest);
    }

    public Continent(string newName) {
        name = newName;
        buildings = new List<int>();
    }

    public Continent() {
        buildings = new List<int>();
    }
}
