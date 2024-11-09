using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BottomUIController
{

    public static void SetSuccess(TextMeshProUGUI textbox, Image backdrop, string message)
    {
        if (textbox != null && backdrop != null)
        {
            Color textColor;
            textColor = new Color(0, 1, 0, 0.5f); // Green with 50% opacity
            textbox.text = message;
            textbox.color = textColor;
        }
    }
    public static void SetFailure(TextMeshProUGUI textbox, Image backdrop, string message)
    {
        if (textbox != null && backdrop != null)
        {
            Color textColor;
            textColor = new Color(1, 0, 0, 0.5f); // Red with 50% opacity
            textbox.text = message;
            textbox.color = textColor;
        }
    }

    public static void SetLog(TextMeshProUGUI textbox, Image backdrop, string message)
    {
        if (textbox != null && backdrop != null)
        {
            Color textColor;
            textColor = new Color(0, 0, 0, 0.5f); // Black with 50% opacity
            textbox.text = message;
            textbox.color = textColor;
        }
    }

}
