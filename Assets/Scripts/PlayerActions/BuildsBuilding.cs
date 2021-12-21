using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsBuilding : MonoBehaviour
{
    public string buildingType;
    private void Start() {
    }

    private void OnMouseDown() {
        GameState.GetContinent("Africa").buildings.Add(XMLOp.DeserializeBuilding("Data/Building_" + buildingType + ".xml"));
        Debug.Log(GameState.GetContinent("Africa").buildings[0].income_elves);
    }
}
