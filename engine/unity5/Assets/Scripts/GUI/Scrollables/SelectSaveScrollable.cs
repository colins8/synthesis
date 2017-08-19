﻿using UnityEngine;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Meant to be used for selecting a save
/// </summary>
public class SelectSaveScrollable : ScrollablePanel
{
    private string directory;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        listStyle.fontSize = 14;
        highlightStyle.fontSize = 14;
        toScale = false;
        errorMessage = "No fields found in directory!";
    }

    void OnEnable()
    {
        directory = PlayerPrefs.GetString("SaveGameDirectory", (System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "//synthesis//GameSaves"));
        items = new List<string>();
        items.Clear();

    }

    // Update is called once per frame
    protected override void OnGUI()
    {
        if (directory != null && items.Count == 0)
        {
            string[] folders = System.IO.Directory.GetDirectories(directory);
            foreach (string saves in folders)
            {
                if (File.Exists(saves + "\\definition.bxdf")) items.Add(new DirectoryInfo(saves).Name);
            }
            if (items.Count > 0) selectedEntry = items[0];
        }

        position = GetComponent<RectTransform>().position;


        base.OnGUI();

    }
}
