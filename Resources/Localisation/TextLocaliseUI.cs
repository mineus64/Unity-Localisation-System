// Component of the Unity Localisation System developed by Nathan Hodson (Subgiant Games) based off of the excellent videos by Matt of GameDevGuide on YouTube
// Use it how you like but please make sure to credit me if you do!

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

[AddComponentMenu("Localisation/TextLocaliseUI")]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliseUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textField;

    public LocalisedString localisedString;

    // Start is called before the first frame update
    void Start()
    {
      if (textField == null) {
        textField = GetComponent<TextMeshProUGUI>();
      }
      // string value = LocalisationSystem.GetLocalisedValue(key);
      textField.text = localisedString.value;
    }
}
