using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] ob;
    public GameObject talk;
    private int context=0;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void onclickground(){
        if(context == 5){
            talk.SetActive(false);
            return;
        }
        ob[context].SetActive(true);
        context = context+1;
    }
}
