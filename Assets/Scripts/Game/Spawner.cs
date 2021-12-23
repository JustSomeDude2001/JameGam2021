using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnableTemplate;

    public void SpawnObject() {
        GameObject.Instantiate(spawnableTemplate, transform);
    }
}
