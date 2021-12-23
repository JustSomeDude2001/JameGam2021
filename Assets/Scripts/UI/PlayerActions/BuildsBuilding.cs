using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsBuilding : MonoBehaviour
{ 
    public string buildingType;
    public bool locked = false;

    void notifyFail() {

    }
    void notifySuccess() {
        Debug.Log("Built building");
    }

    private void OnMouseDown() {
        if (GameState.canBuild(buildingType) && !locked) {
            GameState.build(buildingType);
            notifySuccess();
            locked = true;

            Destroy(gameObject);
        } else {
            notifyFail();
        }
    }
}
