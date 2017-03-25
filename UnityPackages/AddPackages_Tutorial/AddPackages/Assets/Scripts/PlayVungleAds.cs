﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayVungleAds : MonoBehaviour
{


    public Text DebugText;

    public string AppId = "58d3030b64b3bf8742000250";

    Dictionary<string, object> options;


    private void Awake()
    {
        Init(AppId);
        
    }

    private void Start()
    {
        Init(AppId);
    }
   

    private void Init(string AppId)
    {
        Vungle.init(AppId, null, null);
        RequestAd();
    }

    private void RequestAd()
    {
        DebugText.text = "Request Vungle Ad";
        InitializeEventHandlers();
        options = new Dictionary<string, object>();
        options["incentivized"] = true;
    }

    private void InitializeEventHandlers()
    {
        Vungle.onAdStartedEvent += () => {
            DebugText.text = "On Ad Started";
        };

        Vungle.onAdFinishedEvent += (args) =>
        {
            DebugText.text = "On Ad Finished: "+ args.ToString();
            RequestAd();
        };

        Vungle.adPlayableEvent += (adPlayable) => {
            DebugText.text = "This ad is playable: " + adPlayable.ToString();
        };

        Vungle.onLogEvent += (log) => {
            DebugText.text = "This log: "+log.ToString();
        };
    }

    public void PlayAd()
    {
        DebugText.text = "THE BUTTON WAS CLICKED PLAY AD";
        
        Vungle.playAdWithOptions(options);
        RequestAd();

    }

}