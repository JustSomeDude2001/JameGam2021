using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
