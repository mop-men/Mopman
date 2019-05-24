using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playagain : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

// Detects if any key has been pressed down.
    void Update()
    {
        {
        SceneManager.LoadScene("Main");
        }
    }
}