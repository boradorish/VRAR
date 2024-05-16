using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject timerComponents;
    [SerializeField] Image timerGraphic;
    [SerializeField] float gameTime;

    float maxGameTime;
    bool canTimerCountDown = false; 

    private void Awake()
    {
        maxGameTime = gameTime;
        canTimerCountDown=false;
    }

    private void OnEnable()
    {
        // EventListerner to start timer -> once GameFlowModule.Startgame is triggered, runs below code
        GameManager.StartGame += ActivateTimer;
    }

    private void OnDisable()
    {
        // EventListerner to end timer -> once GameFlowModule.Startgame ends, runs below code
        GameManager.StartGame -= ActivateTimer;
    }

    public void ActivateTimer()
    {
        timerComponents.SetActive(true);
        canTimerCountDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTimerCountDown){ 
            return; 
        } else { 
            UpdateTimer();
            CheckTimer(); ;
        }
       
    }

    private void UpdateTimer()
    {
        gameTime -= Time.deltaTime;
        var updateTimerGraphicValue = gameTime / maxGameTime;
        timerGraphic.fillAmount = updateTimerGraphicValue;
    }

    private void CheckTimer()
    {
        if (timerGraphic.fillAmount <= 0f)
        {
            GameManager.Instance.GameOver();
            canTimerCountDown = false;
            gameTime = maxGameTime;
            timerComponents.SetActive(false);
        }
    }

}
