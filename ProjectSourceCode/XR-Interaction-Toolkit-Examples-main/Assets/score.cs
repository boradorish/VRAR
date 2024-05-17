using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    //public bool ischanged = false;
    public static score instance;
    public bool getscore = false;
    int count = 1;
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
        count = 1;
        //Debug.Log("set count as"+count);
    }

    // Update is called once per frame
    void Update()
    {
        if (getscore)
        {
            count++;
            getscore = false;
            //Debug.Log("score_updated, count: " + count + " getscore: "+getscore);
        }
        
    }
}
