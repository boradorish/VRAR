using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class RandomToSocket : MonoBehaviour
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

        
        //socket number 선언
        int[] socket_numbers = new int[sockets.Length];
        for (int i = 0; i < sockets.Length; i++)
        {
            socket_numbers[i] = i;
        }
        Debug.Log($"Socket Length: {sockets.Length}");
        //socket number 무작위 섞기
        for (int i = 0; i < Random.Range(sockets.Length, sockets.Length + objects.Length); i++)
        {
            int j = Random.Range(0, sockets.Length);
            int k = Random.Range(0, sockets.Length);

            int temp = socket_numbers[j];
            socket_numbers[j] = socket_numbers[k];
            socket_numbers[k] = temp;
        }
        //mixed socket number 확인
        Debug.Log("Mixed Socket numbers");
        for (int i = 0; i < sockets.Length; i++)
        {
            Debug.Log(socket_numbers[i]);
        }

        
        //object number 선언
        int[] object_numbers = new int[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            object_numbers[i] = i;
        }
        Debug.Log($"Object Length: {objects.Length}");
        //object number 무작위 섞기
        for (int i = 0; i < Random.Range(objects.Length, objects.Length + sockets.Length); i++)
        {
            int j = Random.Range(0, objects.Length);
            int k = Random.Range(0, objects.Length);

            int temp = object_numbers[j];
            object_numbers[j] = object_numbers[k];
            object_numbers[k] = temp;
        }
        //mixed object number 확인
        Debug.Log("Mixed Object numbers");
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log(object_numbers[i]);
        }


        //objects 3개만 random sockets으로 이동
        for (int i = 0; i < 3; i++)
        {
            int j = socket_numbers[i];
            int k = object_numbers[i];

            if (objects[k] != null && sockets[j] != null)
            {
                //주의: Object의 Rigidbody Component에서 Interpolate: none으로 설정해야 작동함
                objects[k].transform.position = sockets[j].transform.position;

                Debug.Log($"object[{k}]: {objects[k]} moved to socket[{j}]: {sockets[j]}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
