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
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    private void Start()
    {
        //TextMeshProUGUI[] textElements = canvas.GetComponentsInChildren<TextMeshProUGUI>();

        
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
        textColor = new Color(0, 0.7f, 0); 
        backdrop.color = textColor;
    }
    public void SetFailure()
    {
        Color textColor;
        textColor = new Color(0.7f, 0, 0); 
        backdrop.color = textColor;
    }

    public void SetLog()
    {
        Color textColor;
        textColor = new Color(0, 0, 0,0.7f);
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
