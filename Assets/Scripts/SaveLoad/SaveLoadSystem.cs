using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadSystem
{
    /***
    public static void Save(GameState state) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, state);
        stream.Close();
    }

    public static GameState Load() {
        string path = Application.persistentDataPath + "/save";

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameState newState = formatter.Deserialize(stream) as GameState;

            stream.Close();

            return newState;
        } else {
            Debug.Log("No save file in " + path);
            return null;
        }
    }
    ***/
}
