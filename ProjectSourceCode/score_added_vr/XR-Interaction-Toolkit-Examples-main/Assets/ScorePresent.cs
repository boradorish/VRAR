using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ScorePresent: MonoBehaviour
{
    
    //empty object�� score object�� �ҷ��� ����
    public score obj;


    private int number;

    //
    private float distance;
    private float error = 0.1F;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score.instance.count);
    }

    
}
