using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.InputSystem.XR;

public class BottomUIController : MonoBehaviour
{
    public static BottomUIController Instance { get; private set; }
    public GameObject canvas; // Assign your canvas GameObject here

    // Variables to store specific TextMeshPro components
    public TextMeshProUGUI title;
    public Image backdrop;
    public TextMeshProUGUI description;

    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this as the singleton instance
        Instance = this;

        // Optional: Make this GameObject persistent between scenes
        // Uncomment the line below if you want UIController to persist
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //TextMeshProUGUI[] textElements = canvas.GetComponentsInChildren<TextMeshProUGUI>();

        //// Loop through each element and store based on name
        //foreach (TextMeshProUGUI textElement in textElements)
        //{
        //    if (textElement.name == "Title")
        //    {
        //        title = textElement;
        //    }
        //    else if (textElement.name == "Description")
        //    {
        //        description = textElement;
        //    }
        //}
    }

    public void SetSuccess()
    {
        Color textColor;
        textColor = new Color(0, 0.7f, 0); // Green with 50% opacity
        backdrop.color = textColor;
    }
    public void SetFailure()
    {
        Color textColor;
        textColor = new Color(0.7f, 0, 0); // Green with 50% opacity
        backdrop.color = textColor;
    }

    public void SetLog()
    {
        Color textColor;
        textColor = new Color(0, 0, 0,0.7f); // Green with 50% opacity
        backdrop.color = textColor;
    }

    public void SetWarning()
    {
        Color textColor;
        textColor = new Color(0.6f, 0.6f, 0,0.7f);
        backdrop.color = textColor;
    }

    public void SetTitle(string message)
    {
        title.text = message;
    }
    public void SetDescription(string message)
    {
        description.text = message;
    }

    

}
