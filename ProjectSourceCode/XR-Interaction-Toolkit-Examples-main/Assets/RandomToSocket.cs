using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class RandomToSocket : MonoBehaviour
{
    //random ��ġ function���� ȣ��� �� �ִ� public ����
    //IsCollisionOver ��ũ��Ʈ���� ������, ��� ���̴��� �𸣰���
    public int socket_number = 0;
    public int object_number = 0;
    public int number_of_modified_objects = 1;

    GameObject[] sockets;
    GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {

        //sockets, objects ������ ��� ���������� Ȯ�� �ʿ�
        sockets = GameObject.FindGameObjectsWithTag("sockets");
        objects = GameObject.FindGameObjectsWithTag("objects");

        
        //socket number ����
        int[] socket_numbers = new int[sockets.Length];
        for (int i = 0; i < sockets.Length; i++)
        {
            socket_numbers[i] = i;
        }
        Debug.Log($"Socket Length: {sockets.Length}");
        //socket number ������ ����
        for (int i = 0; i < Random.Range(sockets.Length, sockets.Length + objects.Length); i++)
        {
            int j = Random.Range(0, sockets.Length);
            int k = Random.Range(0, sockets.Length);

            int temp = socket_numbers[j];
            socket_numbers[j] = socket_numbers[k];
            socket_numbers[k] = temp;
        }
        //mixed socket number Ȯ��
        Debug.Log("Mixed Socket numbers");
        for (int i = 0; i < sockets.Length; i++)
        {
            Debug.Log(socket_numbers[i]);
        }

        
        //object number ����
        int[] object_numbers = new int[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            object_numbers[i] = i;
        }
        Debug.Log($"Object Length: {objects.Length}");
        //object number ������ ����
        for (int i = 0; i < Random.Range(objects.Length, objects.Length + sockets.Length); i++)
        {
            int j = Random.Range(0, objects.Length);
            int k = Random.Range(0, objects.Length);

            int temp = object_numbers[j];
            object_numbers[j] = object_numbers[k];
            object_numbers[k] = temp;
        }
        //mixed object number Ȯ��
        Debug.Log("Mixed Object numbers");
        for (int i = 0; i < objects.Length; i++)
        {
            Debug.Log(object_numbers[i]);
        }


        //objects 3���� random sockets���� �̵�
        for (int i = 0; i < 3; i++)
        {
            int j = socket_numbers[i];
            int k = object_numbers[i];

            if (objects[k] != null && sockets[j] != null)
            {
                //����: Object�� Rigidbody Component���� Interpolate: none���� �����ؾ� �۵���
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
