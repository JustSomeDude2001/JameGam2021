using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public static List <Continent> continents;

    public static int elves = 0;
    public static int humans = 0;
    public static int gifts = 0;
    public static int resources = 0;
    public static int metals = 0;

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
    }
}
