using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class GameState
{
    public static int weeks = 52;
    public static List <Continent> continents;

    public static List <ResourceCount> resources;
    public static List <float> income;
    public static List <float> maint;
    public static List <float> income_modifiers;
    public static List <float> maint_modifiers;

    public static List <Building> buildings;

    public static List <Decision> decisions;
    public static List <bool> enacted;

    public static Continent GetContinent(string name) {
        for (int i = 0; i < continents.Count; i++) {
            if (continents[i].name == name) {
                return continents[i];
            }
        }
        return null;
    }

    static Building getCandidateBuilding(string name) {
        return buildings[getCandidateBuildingIndex(name)];
    }

    static int getCandidateBuildingIndex(string name) {
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

    public static bool canBuild(string building, string location) {
        Building target = getCandidateBuilding(building);
        foreach (ResourceCount curval in resources) {
            if (curval.value < target.getResource(curval.name, target.costs)) {
                return false;
            }
        }
        return true;
    }

    public static void build(string building, string location) {
        Building target = getCandidateBuilding(building);
        int index = getCandidateBuildingIndex(building);
        foreach (ResourceCount curval in resources) {
            curval.value -= target.getResource(curval.name, target.costs);
        }
        GetContinent(location).buildings[index]++;
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
        RecalculateDeltas();
    }

    public static void RecalculateDeltas() {
        for (int i = 0; i < resources.Count; i++) {
            income_modifiers[i] = 1;
            maint_modifiers[i] = 1;
            income[i] = 0;
            maint[i] = 0;
        }

        for (int i = 0; i < decisions.Count; i++) {
            if (enacted[i]) {
                for (int j = 0; j < resources.Count; j++) {
                    income_modifiers[i] += decisions[i].getResource(resources[i].name, decisions[i].income_modifiers);
                    maint_modifiers[i] += decisions[i].getResource(resources[i].name, decisions[i].maint_modifiers);
                }
            }
        }

        for (int i = 0; i < continents.Count; i++) {
            for (int j = 0; j < resources.Count; j++) {
                income[j] += continents[i].getIncome(resources[j].name);
                maint[j] += continents[i].getMaint(resources[j].name);
            }
        }

        for (int i = 0; i < resources.Count; i++) {
            income[i] *= income_modifiers[i];
            maint[i] *= maint_modifiers[i];
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
        RecalculateDeltas();
        weeks--;
        for (int i = 0; i < resources.Count; i++) {
            resources[i].value += income[i];
            resources[i].value -= maint[i];
        }
        if (isBankrupt()) {
            //TO-DO game over screen
        }

    }

    public static void NewGame() {
        continents = new List<Continent>();
        resources = new List<ResourceCount>();
        income = new List<float>();
        maint = new List<float>();
        buildings = new List<Building>();
        income_modifiers = new List<float>();
        maint_modifiers =  new List<float>();


        foreach(string file in Directory.EnumerateFiles("", "Resource_*.xml", SearchOption.AllDirectories)) {
            Resource newResource = XMLOp.DeserializeResource(file);
            resources.Add(newResource.getBase());
            income.Add(0);
            maint.Add(0);
            income_modifiers.Add(0);
            maint_modifiers.Add(0);
        }

        foreach(string file in Directory.EnumerateFiles("", "Building_*.xml", SearchOption.AllDirectories)) {
            Building newBuilding = XMLOp.DeserializeBuilding(file);
            buildings.Add(newBuilding);
        }

        foreach(string file in Directory.EnumerateFiles("", "Decision_*.xml", SearchOption.AllDirectories)) {
            Decision newDecision = XMLOp.DeserializeDecision(file);
            decisions.Add(newDecision);
        }

        Debug.Log(buildings.Count.ToString() + " buildings loaded");

        continents.Add(new Continent("North America"));
        continents.Add(new Continent("South America"));
        continents.Add(new Continent("Africa"));
        continents.Add(new Continent("Europe"));
        continents.Add(new Continent("Asia"));
        continents.Add(new Continent("Australia"));

        for(int i = 0; i < continents.Count; i++) {
            for (int j = 0; j < buildings.Count; j++) {
                continents[i].buildings.Add(0);
                continents[i].buildings[j] = 0;
            }
        }
    }
}
