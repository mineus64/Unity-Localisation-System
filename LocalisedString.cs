// Component of the Unity Localisation System developed by Nathan Hodson (Subgiant Games) based off of the excellent videos by Matt of GameDevGuide on YouTube
// Use it how you like but please make sure to credit me if you do!

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LocalisedString
{
    public string key;

    public LocalisedString(string key) 
    {
      this.key = key;
    }

    public string value {
      get {
        return LocalisationSystem.GetLocalisedValue(key);
      }
    }

    public static implicit operator LocalisedString(string key) 
    {
      return new LocalisedString(key);
    }
}
