using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameObject presser;
    bool isPressed;

    void Start()
    {
        isPressed = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == presser) {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }


}
