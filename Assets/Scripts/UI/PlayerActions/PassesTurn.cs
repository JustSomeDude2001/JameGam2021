using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassesTurn : MonoBehaviour
{
    private void Start() {
        GameState.NewGame();
    }

    public void NextTurn() {
        GameState.NextTurn();

        List<GameObject> toDestroy = new List<GameObject>(GameObject.FindGameObjectsWithTag("Temporary"));

        for (int i = 0; i < toDestroy.Count; i++) {
            Destroy(toDestroy[i]);
        }
        
        List<GameObject> spawners = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawner"));

        Debug.Log("Found spawners: " + spawners.Count.ToString());

        for (int i = 0; i < spawners.Count; i++) {
            Spawner spawner = spawners[i].GetComponent<Spawner>();
            spawner.SpawnObject();
        }
    }
}
