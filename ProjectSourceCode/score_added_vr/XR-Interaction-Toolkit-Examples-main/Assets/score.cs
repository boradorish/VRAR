using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    //public bool ischanged = false;
    public static score instance;
    public int count = 0;
    public GameObject[] sockets;
    public GameObject[] objects;
    public bool[] counted;
    private float dist;
    private float err;
    
    private void Awake()
    {
        if(score.instance == null)
        {
            score.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        err = 0.1f;
        objects = GameObject.FindGameObjectsWithTag("objects");
        sockets = GameObject.FindGameObjectsWithTag("originalsockets");
        counted = new bool[objects.Length];
        
        //Debug.Log("length: "+objects.Length);

        for (int i=0;i<objects.Length;i++)
        {
            switch (objects[i].name)
            {
                case "bbird":
                    sockets[i] = GameObject.Find("bbirdsocket");
                    break;
                case "gbird":
                    sockets[i] = GameObject.Find("gbirdsocket");
                    break;
                case "mouse":
                    sockets[i] = GameObject.Find("mousesocket");
                    break;
                case "game":
                    sockets[i] = GameObject.Find("gamesocket");
                    break;
                case "wine":
                    sockets[i] = GameObject.Find("winesocket");
                    break;
                case "brush":
                    sockets[i] = GameObject.Find("brushsocket");
                    break;
                default:
                    Debug.LogWarning("No socket found for object: " + objects[i].name);
                    break;
            }
            //Debug.Log("number: "+ i + " Name: "+objects[i].name + " Socket: " + sockets[i].name);
            counted[i] = false;
        }
        //Debug.Log("set count as"+count);
    }

    // Update is called once per frame
    void Update()
    {
        for (int j = 0;j<objects.Length;j++)
        {
            dist = Vector3.Distance(sockets[j].transform.position, objects[j].transform.position);
            if(dist < err && !counted[j])
            {
                count++;
                counted[j] = true;
            }
            //Debug.Log(objects[j]+ " distance: "+dist +" count: " + count);
            //Debug.Log(j + " : "+ counted[j]);
        }
    }
}
