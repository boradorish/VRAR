using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MoveToSocket : MonoBehaviour
{
    //random 배치 function에서 호출될 수 있는 public 변수
    //IsCollisionOver 스크립트에서 가져옴, 어디 쓰이는지 모르겠음
    public int socket_number = 0;
    public int object_number = 0;
    public int number_of_modified_objects = 1;

    GameObject[] sockets;
    GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {

        //sockets, objects 순서가 어떻게 정해지는지 확인 필요
        sockets = GameObject.FindGameObjectsWithTag("sockets");
        objects = GameObject.FindGameObjectsWithTag("objects");


        //objects 모두 순서대로 sockets으로 이동
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null && sockets[i] != null)
            {
                //주의: Object의 Rigidbody Component에서 Interpolate: none으로 설정해야 작동함
                objects[i].transform.position = sockets[i].transform.position;

                Debug.Log($"object[{i}]: {objects[i]} moved to socket[{i}]: {sockets[i]}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
