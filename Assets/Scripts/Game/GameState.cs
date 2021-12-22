using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class GameState
{
    public static List <Continent> continents;

    public static List <ResourceCount> resources;
    public static List <ResourceCount> deltas;

    public static Continent GetContinent(string name) {
        for (int i = 0; i < continents.Count; i++) {
            if (continents[i].name == name) {
                return continents[i];
            }
        }
        return null;
    }

    public static void NewGame() {
        continents = new List<Continent>();

        continents.Add(new Continent("North America"));
        continents.Add(new Continent("South America"));
        continents.Add(new Continent("Africa"));
        continents.Add(new Continent("Europe"));
        continents.Add(new Continent("Asia"));
        continents.Add(new Continent("Australia"));

        resources = new List<ResourceCount>();
        deltas = new List<ResourceCount>();

        foreach(string file in Directory.EnumerateFiles("Core/Resources", "*.xml", SearchOption.AllDirectories)) {
            Resource newResource = XMLOp.DeserializeResource(file);
            resources.Add(newResource.getBase());
            deltas.Add(newResource.getZero());
        }

        foreach(string file in Directory.EnumerateFiles("Core/Buildings", "*.xml", SearchOption.AllDirectories)) {
            Building newBuilding = XMLOp.DeserializeBuilding(file);
            
        }
    }
}
