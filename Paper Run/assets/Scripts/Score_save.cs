﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_save : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}





    private static Score_save m_instance;
    private const int LeaderboardLength = 10;


    public static Score_save _instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameObject("Score_save").AddComponent<Score_save>();
            }
            return m_instance;
        }
    }

    /*
    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    */

    public void SaveHighScore(string name, float score)
    {
        List<Scores> HighScores = new List<Scores>();

        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetFloat("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }
        if (HighScores.Count == 0)
        {
            Scores _temp = new Scores();
            _temp.name = name;
            _temp.score = score;
            HighScores.Add(_temp);
        }
        else
        {
            for (i = 1; i <= HighScores.Count && i <= LeaderboardLength; i++)
            {
                if (score > HighScores[i - 1].score)
                {
                    Scores _temp = new Scores();
                    _temp.name = name;
                    _temp.score = score;
                    HighScores.Insert(i - 1, _temp);
                    break;
                }
                if (i == HighScores.Count && i < LeaderboardLength)
                {
                    Scores _temp = new Scores();
                    _temp.name = name;
                    _temp.score = score;
                    HighScores.Add(_temp);
                    break;
                }
            }
        }

        i = 1;
        while (i <= LeaderboardLength && i <= HighScores.Count)
        {
            PlayerPrefs.SetString("HighScore" + i + "name", HighScores[i - 1].name);
            PlayerPrefs.SetFloat("HighScore" + i + "score", HighScores[i - 1].score);
            i++;
        }

    }

    public List<Scores> GetHighScore()
    {
        List<Scores> HighScores = new List<Scores>();

        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            Scores temp = new Scores();
            temp.score = Mathf.Round(PlayerPrefs.GetFloat("HighScore" + i + "score"));
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }

        return HighScores;
    }

    public void ClearLeaderBoard()
    {
        //for(int i=0;i<HighScores.
        List<Scores> HighScores = GetHighScore();

        for (int i = 1; i <= HighScores.Count; i++)
        {
            PlayerPrefs.DeleteKey("HighScore" + i + "name");
            PlayerPrefs.DeleteKey("HighScore" + i + "score");
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

}
