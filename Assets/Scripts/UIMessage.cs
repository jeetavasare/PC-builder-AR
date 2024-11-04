using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI uIMessageHolder;
    public void DisplayMessage(string message)
    {
        uIMessageHolder.text = message;
    }
}
