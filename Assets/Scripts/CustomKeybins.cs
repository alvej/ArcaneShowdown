using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomKeybins : MonoBehaviour
{
    public KeyCode exitMatch = KeyCode.Escape;
    void Update()
    {
        if(Input.GetKeyDown(exitMatch)) {
            SceneManager.LoadScene("TitleScreen");
        }
            
    }
}
