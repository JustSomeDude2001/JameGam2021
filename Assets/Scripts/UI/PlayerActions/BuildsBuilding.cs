using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsBuilding : MonoBehaviour
{ 
    public string buildingType;
    public string location;

    void notifyFail() {

    }
    void notifySuccess() {

    }

    private void OnMouseDown() {
        if (GameState.canBuild(buildingType, location)) {
            GameState.build(buildingType, location);
            notifySuccess();
        } else {
            notifyFail();
        }
    }
}
