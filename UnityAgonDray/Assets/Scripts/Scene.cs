using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    private void StartGame()
    {
        SceneManager.LoadScene(1); //loads the gameLevel
    }


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2); //loads the exitCanvas? The canvas that's after Level
    }
}
