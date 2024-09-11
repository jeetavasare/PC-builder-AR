using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line


public class StartButtonController : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
