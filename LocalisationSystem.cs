// Component of the Unity Localisation System developed by Nathan Hodson (Subgiant Games) based off of the excellent videos by Matt of GameDevGuide on YouTube
// Use it how you like but please make sure to credit me if you do!

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LocalisationSystem : MonoBehaviour
{
    public enum Language 
    {
      EnglishUS,
      EnglishUK,
      Spanish,
      German,
      French,
      Japanese,
      Korean
    }

    public static Language language = Language.EnglishUK;

    public static Dictionary<string, string> localisedEN_US;
    public static Dictionary<string, string> localisedEN_UK;
    public static Dictionary<string, string> localisedES;
    public static Dictionary<string, string> localisedDE;
    public static Dictionary<string, string> localisedFR;
    public static Dictionary<string, string> localisedJA;
    public static Dictionary<string, string> localisedKO;

    public static Dictionary<string, string> GetDictionaryForEditor() 
    {
      if (!isInit) {
        Init();
      }
      return localisedEN_UK;
    }

    public static bool isInit;

    public static CSVLoader csvLoader;

    public static void Init() 
    {
      csvLoader = new CSVLoader();
      csvLoader.LoadCSV();

      UpdateDictionaries();

      isInit = true;
    }

    public static void UpdateDictionaries() 
    {
      localisedEN_US = csvLoader.GetDictionaryValues("en_us");
      localisedEN_UK = csvLoader.GetDictionaryValues("en_uk");
      localisedES = csvLoader.GetDictionaryValues("es");
      localisedDE = csvLoader.GetDictionaryValues("de");
      localisedFR = csvLoader.GetDictionaryValues("fr");
      localisedJA = csvLoader.GetDictionaryValues("ja");
      localisedKO = csvLoader.GetDictionaryValues("ko");
    }

    public static string GetLocalisedValue(string key) 
    {
      if (!isInit) {
        Init();
      }

      string value = key;

      switch(language)
      {
        case Language.EnglishUS:
          localisedEN_US.TryGetValue(key, out value);
          break;
        case Language.EnglishUK:
          localisedEN_UK.TryGetValue(key, out value);
          break;
        case Language.Spanish:
          localisedES.TryGetValue(key, out value);
          break;
        case Language.German:
          localisedDE.TryGetValue(key, out value);
          break;
        case Language.French:
          localisedFR.TryGetValue(key, out value);
          break;
        case Language.Japanese:
          localisedJA.TryGetValue(key, out value);
          break;
        case Language.Korean:
          localisedKO.TryGetValue(key, out value);
          break;
      }

      return value;
    }

    public static void Add(string key, string value) 
    {
      if (value.Contains("\"")) {
        value.Replace('"', '\"');
      }

      if (csvLoader == null) {
        csvLoader = new CSVLoader();
      }

      csvLoader.LoadCSV();
      csvLoader.Add(key, value);
      csvLoader.LoadCSV();

      UpdateDictionaries();
    }

    public static void Replace(string key, string value) 
    {
      if (value.Contains("\"")) {
        value.Replace('"', '\"');
      }

      if (csvLoader == null) {
        csvLoader = new CSVLoader();
      }

      csvLoader.LoadCSV();
      csvLoader.Edit(key, value);
      csvLoader.LoadCSV();

      UpdateDictionaries();
    }

    public static void Remove(string key) 
    {
      if (csvLoader == null) {
        csvLoader = new CSVLoader();
      }

      csvLoader.LoadCSV();
      csvLoader.Remove(key);
      csvLoader.LoadCSV();

      UpdateDictionaries();
    }
}
