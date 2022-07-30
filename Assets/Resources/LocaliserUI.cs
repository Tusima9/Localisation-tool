using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI))]
public class LocaliserUI : MonoBehaviour
{
 
    TextMeshProUGUI  textField;

    //  public string key;
    public LocalisedString localisedString;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        //   string value = LocalisationSystem.GetLocalisedValue(key);
        //textField.text = value;
        textField.text = localisedString.value;
    }

 
}
