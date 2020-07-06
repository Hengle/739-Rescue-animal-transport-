using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseInitial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.LogError("FirebaseApp FirebaseInitial");

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
                Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
                
                Debug.LogError("FirebaseApp is Ready");
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //   app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                Debug.LogError("FirebaseApp is Not to use");
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

        
    }
   
    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
    {
        Debug.LogError("Received Registration Token: " + token.Token);
    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        Debug.LogError("Received a new message from: " + e.Message.From);
        Debug.LogError("Received a new message Data Value: " + e.Message.Data.Values);

        try
        {
            if (e.Message.NotificationOpened)
            {
                CustomAnalytics.logNotificationOpened("Notification_Opened");
            }
            else
            {
                CustomAnalytics.logNotificationOpened("Notification_Received");
            }

        }
        catch
        {
            Debug.LogError("FirebaseApp is Not to use in Message Received");

        }

        try
        {
            foreach (string str in e.Message.Data.Values)
            {
                Debug.LogError("Received a new message Data Value: " + str);
                if (e.Message.NotificationOpened)
                {
                    CustomAnalytics.logNotificationOpened("Click");
                    Application.OpenURL(str);

                }
            }

        }
        catch
        {
            Debug.LogError("OnMessageReceived Failed");
        }

        

        //Debug.LogError("Received a new message CollapseKey: " + e.Message.CollapseKey);
        //Debug.LogError("Received a new message Link: " + e.Message.Link);
        //Debug.LogError("Received a new message MessageId: " + e.Message.MessageId);
        //Debug.LogError("Received a new message String: " + e.Message.ToString());
        //Debug.LogError("Received a new message NotificationOpened: " + e.Message.NotificationOpened);
        //Debug.LogError("Received a new message Notifications: " + e.Message.Notification);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        Firebase.Messaging.FirebaseMessaging.MessageReceived -= OnMessageReceived;
        Firebase.Messaging.FirebaseMessaging.TokenReceived -= OnTokenReceived;
    }
}
