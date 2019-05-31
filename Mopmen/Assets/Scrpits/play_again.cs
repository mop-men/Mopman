using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play_again : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

// Detects if any key has been pressed down.
  public void play_again_button()
    {
        SceneManager.LoadScene("Main");
    }
}