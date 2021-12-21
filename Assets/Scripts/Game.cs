using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Game
{
    static Game instance;

    public static Game LoadGame(string SaveName = "SaveGame.json") {
        string json = File.ReadAllText(SaveName);
        Game newGame = JsonUtility.FromJson<Game>(json);

        return newGame;
    }

    public static Game NewGame() {
        return LoadGame("NewGame.json");
    } 

    public static Game getInstance() {
        if (instance == null) {
            instance = LoadGame();
        }
        return instance;
    }
}
