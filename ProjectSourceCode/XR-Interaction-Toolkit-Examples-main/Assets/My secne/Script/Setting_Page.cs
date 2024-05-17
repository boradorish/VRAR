using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_Page : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle difficult;
    public Toggle normal;
    public Toggle easy;

    public Animator xbutton;
    public GameObject Target;

    private int difficulty;

    void Start()
    {
        this.difficulty = 2;
    }

    // Update is called once per frame
    public void DifficultyChanger(int num) {   // TODO: 토글 클릭 시, isOn 항목 저장 후 복원
        switch (num) {
            case 1 :
                this.easy.SetIsOnWithoutNotify(true);
                this.normal.SetIsOnWithoutNotify(false);
                this.difficult.SetIsOnWithoutNotify(false);
                Debug.Log("easy");
                this.difficulty = 1;
                break;

            case 2 :
                this.easy.SetIsOnWithoutNotify(false);
                this.normal.SetIsOnWithoutNotify(true);
                this.difficult.SetIsOnWithoutNotify(false);
                Debug.Log("normal");
                this.difficulty = 2;
                break;

            case 3 :
                this.easy.SetIsOnWithoutNotify(false);
                this.normal.SetIsOnWithoutNotify(false);
                this.difficult.SetIsOnWithoutNotify(true);
                Debug.Log("difficult");
                this.difficulty = 3;
                break;

        }
    }

    public void X_button_click(){
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay(){
        xbutton.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        Target.SetActive(false);
        xbutton.ResetTrigger("close");
    }
}
