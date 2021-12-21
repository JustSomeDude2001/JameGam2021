using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Clicker : MonoBehaviour
{
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(counter);
    }

    private void Update() {
        if (Input.anyKeyDown) {
            counter++;
            Debug.Log("Clicked");
            Debug.Log(Application.dataPath);
        }
    }
}
