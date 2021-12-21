using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    private void OnMouseDown() {
        GameState.NewGame();
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
