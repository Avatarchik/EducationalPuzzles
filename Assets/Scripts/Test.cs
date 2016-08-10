using System;
using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class Test : MonoBehaviour
{

//	public void TestM()
//	{
//
//		PlayGamesPlatform.DebugLogEnabled = true;
//		PlayGamesPlatform.Activate();
//
//		Social.localUser.Authenticate(authenticated =>
//		{
//			if (!authenticated || !Social.localUser.authenticated)
//			{
//				throw new Exception();
//			}
//
//			Social.ReportScore(1000, "CgkIqpj0974PEAIQAQ", (bool success) =>
//			{
//				if (success)
//				{
//					Social.ShowAchievementsUI();
//				}
//				else
//				{
//					throw new Exception();
//				}
//			});
//		});
//	}

    public Text DebugText;
    public Button Add;
    public Button Show;
    public Button LoginButton;

    public int incrementalCount = 5;

    //leaderboard strings
    private string leaderboard = TestLeaderboard.leaderboard_scores;

    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;

        Add.onClick.AddListener(AddPoint);
        Show.onClick.AddListener(ShowLead);
        LoginButton.onClick.AddListener(Login);
    }

    // Update is called once per frame
    public void Login()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("You've successfully logged in");
                DebugText.text = "Авторизация ОК";
            }
            else
            {
                Debug.Log("Login failed for some reason");
                DebugText.text = "Авторизация НЕ ОК";
			 Debug.Log(Social.localUser.authenticated);
            }
        });
    }

    public void AddPoint()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(50, leaderboard, (bool success) =>
            {
                if (success)
                {
                    ((PlayGamesPlatform) Social.Active).ShowLeaderboardUI(leaderboard);
                    DebugText.text = "ДОБАВИЛОСЬ";
                }
                else
                {
                    Debug.Log("Login failed for some reason");
                    DebugText.text = "Ну удалось добавить";
                }
            });
        }
    }

    public void ShowLead()
    {
        Social.ShowLeaderboardUI();
    }

//        //Sign Out
//        if (GUILayout.Button("Выход"))
//        {
//            ((PlayGamesPlatform)Social.Active).SignOut();
//        }
//    }
}
