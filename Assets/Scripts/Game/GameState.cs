using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class GameState
{
    public static float unrest = 0f;
    public static int weeks = 52;

    public static List <Resource> resourcesDescs;
    public static List <ResourceCount> resources;
    public static List <float> income;
    public static List <float> income_modifiers;

    public static List <Building> buildings;
    public static List <int> buildingCounts;

    public static List <Decision> decisions;
    public static List <bool> enacted;

    public static float getIncome(string resource) {
        float result = 0;
        for (int i = 0; i < buildingCounts.Count; i++) {
            result += buildings[i].getResource(resource, GameState.buildings[i].income) * (float)buildingCounts[i];
        }
        return result * (1f);
    }

    public static float getResource(string name) {
        for (int i = 0; i < resources.Count; i++) {
            if (resources[i].name == name) {
                return resources[i].value;
            }
        }
        return -1;
    }

    public static string getResourceSkin(string name) {
        for (int i = 0; i < resources.Count; i++) {
            if (resources[i].name == name) {
                return resourcesDescs[i].skin;
            }
        }
        return null;
    }

    public static float getModifier(string name) {
        for (int i = 0; i < resources.Count; i++) {
            if (resources[i].name == name) {
                return income_modifiers[i];
            }
        }
        return 1;
    }

    public static string getResourceDescription(string name) {
        for (int i = 0; i < resources.Count; i++) {
            if (resources[i].name == name) {
                return resourcesDescs[i].description;
            }
        }
        return "LOL PROGRAMMER'S A LOSER AHAHAHAHAH";
    }

    public static Decision getDecision(string name) {
        for (int i = 0; i < decisions.Count; i++) {
            if (decisions[i].name == name) {
                return decisions[i];
            }
        }
        return null;
    }

    static public Building getBuilding(string name) {
        return buildings[getBuildingIndex(name)];
    }

    static int getBuildingIndex(string name) {
        for (int i = 0; i < buildings.Count; i++) {
            if(buildings[i].name == name) {
                return i;
            }
        }  

        return -1;
    }
    static Decision getCandidateDecision(string name) {
        return decisions[getCandidateDecisionIndex(name)];
    }

    static int getCandidateDecisionIndex(string name) {
        for (int i = 0; i < decisions.Count; i++) {
            if(decisions[i].name == name) {
                return i;
            }
        }  

        return -1;
    }

    public static bool canBuild(string building) {
        Building target = getBuilding(building);
        foreach (ResourceCount curval in resources) {
            if (curval.value < target.getResource(curval.name, target.costs)) {
                return false;
            }
        }
        return true;
    }

    public static void build(string building) {
        Building target = getBuilding(building);
        int index = getBuildingIndex(building);
        foreach (ResourceCount curval in resources) {
            curval.value -= target.getResource(curval.name, target.costs);
        }
        buildingCounts[index]++;
        RecalculateDeltas();
    }

    public static bool canEnact(string decision) {
        Decision target = getCandidateDecision(decision);
        foreach (ResourceCount curval in resources) {
            if (curval.value < target.getResource(curval.name, target.costs)) {
                return false;
            }
        }
        return true;
    }

    public static void enactDecision(string decision) {
        Decision target = getCandidateDecision(decision);
        int index = getCandidateDecisionIndex(decision);
        foreach (ResourceCount curval in resources) {
            curval.value -= target.getResource(curval.name, target.costs);
        }
        enacted[index] = true;
        Debug.Log("Decision " + index.ToString() + " enacted");
        RecalculateDeltas();
    }

    public static void RecalculateDeltas() {
        for (int i = 0; i < resources.Count; i++) {
            income_modifiers[i] = 1;
            income[i] = 0;
        }

        for (int i = 0; i < decisions.Count; i++) {
            if (enacted[i]) {
                Debug.Log("Updating modifiers. Decision enacted:" + i.ToString());
                for (int j = 0; j < resources.Count; j++) {
                    income_modifiers[j] += decisions[i].getResource(resources[j].name, decisions[i].income_modifiers);
                }
            }
        }

        for (int j = 0; j < resources.Count; j++) {
            income[j] += getIncome(resources[j].name);
        }
        
        for (int i = 0; i < resources.Count; i++) {
            income[i] *= income_modifiers[i];
        }
    }

    public static bool canEnactAny() {
        for (int i = 0; i < enacted.Count; i++) {
            if (!enacted[i] && (decisions[i].prerequisiteDecision == "" || enacted[getCandidateDecisionIndex(decisions[i].prerequisiteDecision)])) {
                return true;
            }
        }
        return false;
    }

    public static string getRandomPossibleDecision() {
        while (true) {
            int id = Random.Range(0, decisions.Count);

            if (enacted[id]) {
                continue;
            }

            if (decisions[id].prerequisiteDecision == "" && !enacted[id]) {
                return decisions[id].name;
            }
            if (enacted[getCandidateDecisionIndex(decisions[id].prerequisiteDecision)] && !enacted[id]) {
                return decisions[id].name;
            }
        }
    }

    public static string getRandomPossibleBuilding() {
        while (true) {
            int id = Random.Range(0, buildings.Count);
            if (buildings[id].prerequisiteDecision == "") {
                return buildings[id].name;
            }
            if (enacted[getCandidateDecisionIndex(buildings[id].prerequisiteDecision)]) {
                return buildings[id].name;
            }
        }
    }

    public static bool isBankrupt() {
        for (int i = 0; i < resources.Count; i++) {
            if (resources[i].value < 0) {
                return true;
            }
        }
        return false;
    }

    public static void NextTurn() {
        Debug.Log("Next Turn");
        RecalculateDeltas();
        Paper.hadDecisionOnBoard = false;
        weeks--;
        for (int i = 0; i < resources.Count; i++) {
            resources[i].value += income[i];
        }
    }

    public static void NewGame() {
        resourcesDescs = new List<Resource>();
        resources = new List<ResourceCount>();
        income = new List<float>();
        buildings = new List<Building>();
        buildingCounts = new List<int>();
        decisions = new List<Decision>();
        enacted = new List<bool>();
        income_modifiers = new List<float>();
  
        foreach(string file in Directory.EnumerateFiles("Core", "Resource_*.xml", SearchOption.AllDirectories)) {
            Resource newResource = XMLOp.DeserializeResource(file);
            resourcesDescs.Add(newResource);
            resources.Add(newResource.getBase());
            income.Add(0);
            income_modifiers.Add(1);
        }

        foreach(string file in Directory.EnumerateFiles("Core", "Building_*.xml", SearchOption.AllDirectories)) {
            Building newBuilding = XMLOp.DeserializeBuilding(file);
            buildings.Add(newBuilding);
        }

        foreach(string file in Directory.EnumerateFiles("Core", "Decision_*.xml", SearchOption.AllDirectories)) {
            Decision newDecision = XMLOp.DeserializeDecision(file);
            decisions.Add(newDecision);
            enacted.Add(false);
        }

        Debug.Log("Sizes: " + decisions.Count.ToString() + " " + enacted.Count.ToString());

        Debug.Log(buildings.Count.ToString() + " buildings loaded");

        for (int j = 0; j < buildings.Count; j++) {
            buildingCounts.Add(0);
            buildingCounts[j] = 0;
        }
    }
}
