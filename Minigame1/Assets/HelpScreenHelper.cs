﻿using UnityEngine;
using System.Collections;

public class HelpScreenHelper : MonoBehaviour
{
    private GameObject _toturialImage;
    private bool _showToturial;

	// Use this for initialization
	private void Start ()
	{
	    
    }
	
	// Update is called once per frame
	private void Update () {
	    if (_showToturial && _toturialImage == null)
	    {
            _toturialImage = transform.FindChild(LanguageManager.Instance.Get("TorurialName")).gameObject;
            _toturialImage.SetActive(true);
        }
	    if (Input.GetMouseButtonDown(0) && _showToturial)
	    {
	        _showToturial = false;
            _toturialImage.SetActive(false);
	        _toturialImage = null;
	    }
	
	}

    public void ShowToturial()
    {
        _showToturial = true;
        GameObject.FindGameObjectWithTag("Toturial").SetActive(true);
    }
}
