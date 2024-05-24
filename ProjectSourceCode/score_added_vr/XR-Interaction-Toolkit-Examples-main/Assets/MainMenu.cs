using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Animator animator;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_onclick(){
        Debug.Log("New game");
    }
    
    public void setting_onclick(){
        Debug.Log("Setting");
        if (Target.activeSelf == true){
            animator.SetTrigger("open");
        } else{
            Target.SetActive(true);
        }
    }
    
    public void exit_onclick(){
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else 
        Application.Quit();
#endif
    }
    
}
