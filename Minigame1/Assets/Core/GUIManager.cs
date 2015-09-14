﻿using UnityEngine;

public class GUIManager : MonoBehaviour
{
    void Awake()
    {
		/*
        LanguageManager.Instance.LoadLanguage("English");
        Debug.Log(LanguageManager.Instance.Get("Phrases/Hello"));

        LanguageManager.Instance.LoadLanguage("Swedish");
        Debug.Log(LanguageManager.Instance.Get("Phrases/Hello"));
		*/
		if(!PlayerPrefs.HasKey("Language"))
		{
			PlayerPrefs.SetString("Language", "English");
			LanguageManager.Instance.LoadLanguage(PlayerPrefs.GetString ("Language"));
		}
		else
		{
			LanguageManager.Instance.LoadLanguage(PlayerPrefs.GetString ("Language"));
		}
    }

	public void OnStartGameClick()
	{
		Debug.Log ("Start the gaddeim game");
		Application.LoadLevel ("EndlessFallingPrototype");
	}

    public void OnLanguageClick(string language)
    {
        LanguageManager.Instance.LoadLanguage(language);
		PlayerPrefs.SetString ("Language", language);
        LocalizedText[] texts = FindObjectsOfType<LocalizedText>();
        foreach (LocalizedText text in texts)
        {
            text.LocalizeText();
        }
    }

	public void OnCreditsClick()
	{

	}
}