using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Phocoon.IAT;

public class DemoComp : MonoBehaviour
{

    public GameObject JoinLeft;
    public GameObject JoinRight;
    public GameObject Game;
    public GameObject GameUI;
    public GameObject GameUILeft;
    public GameObject GameUIRight;


    void Awake()
    {
        PhocoonIAT.Instance.InitIAT("<Place Your App ID here>");
        PhocoonIAT.Instance.ResolutionChange += (Vector2 resolution) =>
        {
            // Change to target resolution
        };
    }

    void Update()
    {
    }

    public void StartSession(bool left)
    {
        string sessionID = PhocoonIAT.Instance.StartSession();
        Debug.Log("Session ID: " + sessionID);

        UserInfo info = PhocoonIAT.Instance.GetUserInfo();

        PhocoonIAT.Instance.PlayerInfo += (UserInfo userInfo) =>
        {
            // Do something with userInfo
        };

        JoinRight.SetActive(false);
        JoinLeft.SetActive(false);
        GameUI.SetActive(true);
        GameUI.SetActive(true);
        Game.SetActive(true);

        if (left)
        {
            GameUILeft.SetActive(true);
        }
        else
        {
            GameUIRight.SetActive(true);
        }
    }
}