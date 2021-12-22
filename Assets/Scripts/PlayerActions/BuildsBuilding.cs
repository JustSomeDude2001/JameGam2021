using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsBuilding : MonoBehaviour
{ 
    public string buildingType;
    public string location;
    public List<string> techs;
    private void Start() {
        GameState.NewGame();
    }

    private void OnMouseDown() {
        //GameState.GetContinent(location).buildings.Add(XMLOp.DeserializeBuilding("Core/Building/" + buildingType + ".xml"));
    }
}
