



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public delegate void OnGameStart();
    public static event OnGameStart StartGame;

    public delegate void OnGameEnd();
    public static event OnGameEnd EndGame;

    //declare Singleton
    static GameManager instance;
    public static GameManager Instance {
        get { return instance; }
    }
    
    private void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    

    //define score

    private float score = 0;
    private int starAmount = 0;
    
    public int totalNumberOfObjects = 5;

    float maxGameTime = 120.0f;
    float finalTime = 0;

    public float Score { get { return score; } }

    public void PlayerScore(float targetValue) {
        score += targetValue;
        Debug.Log("Players Score: " + score);

    }

    public void GameStart()
    {
        Debug.Log("Game Started");
        StartGame();
    }

    public void GameOver() {
        Debug.Log("Game Ended");
        EndGame();
    }

    public void NumberofStars(int numberFound, int finalTime) 
    {

        this.score = (numberFound / totalNumberOfObjects) * 50 + (finalTime / maxGameTime) * 50;

        if (score < 15)
            starAmount = 0;
        else if (score < 50)
            starAmount = 1;
        else if (score < 70)
            starAmount = 2;
        else
            starAmount = 3;
    }
}
