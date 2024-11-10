//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuController : MonoBehaviour
{
    
    public Button startButton;
    public TMP_Dropdown dropdown;
    public Dropdown dropdown1;
    public TMP_Dropdown dropdown2;
    public string selectedOption;
    public List<string> dropdownItems = new List<string>();  

    void Start()
    {
        
        startButton.onClick.AddListener(OnStartButtonClick);
        
        //PlayerPrefs.SetString("SelectedComponent", "RAM");
        DataHolder.Mode = "Ram";
        //StoreDropdownItems();
    }

    
    public void OnStartButtonClick()
    {
        DataHolder.selectedDropdownText = selectedOption;
        //DataHolder.Mode = selectedOption;
        UnityEngine.Debug.Log("dfsfgsf"+selectedOption);
        //PlayerPrefs.SetString("SelectedComponent", "RAM");

        SceneManager.LoadScene("ComponentSpecDetector");
        
        
    }

    
    //public void StoreDropdownItems()
    //{
    //    dropdownItems.Clear();  

    //    foreach (TMP_Dropdown.OptionData option in dropdown.options)
    //    {
    //        dropdownItems.Add(option.text.ToString());  
    //    }

        
    //    foreach (string item in dropdownItems)
    //    {
    //        Debug.Log(item);  
    //    }
    //}
    public void DropdownValueChanged(TMP_Dropdown change)
    {
        
        selectedOption = change.options[change.value].text;
        DataHolder.Mode = selectedOption;
        //PlayerPrefs.SetString("SelectedComponent", selectedOption);
        Debug.Log("New Selected Option: " + selectedOption);
    }
    
    void Update()
    {
        
    }
}
