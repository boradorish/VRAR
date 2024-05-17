using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MoveToSocket : MonoBehaviour
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


        //objects ��� ������� sockets���� �̵�
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null && sockets[i] != null)
            {
                //����: Object�� Rigidbody Component���� Interpolate: none���� �����ؾ� �۵���
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
