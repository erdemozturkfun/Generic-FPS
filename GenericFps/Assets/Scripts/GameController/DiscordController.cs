using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;


public class DiscordController : MonoBehaviour
{
    private ActivityManager activityManager;
    public Discord.Discord discord;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
        
    }

    private void Init()
    {
        discord = new Discord.Discord(JsonParser.dc_clientkey, (System.UInt64) Discord.CreateFlags.Default);
        activityManager = discord.GetActivityManager();
        Activity activity = new Activity{
            Details = "Test Map",
            Timestamps = {
                
                Start = 21
                
            }   
        };
            activityManager.UpdateActivity(activity, (result) =>
            {
                if (result == Discord.Result.Ok)
                {
                    Debug.Log("Success!");
                }
                else
                {
                    Debug.Log("Failed");
                }
            });
    }

    private void OnApplicationQuit()
    {
        
        discord.Dispose();
    }
}
