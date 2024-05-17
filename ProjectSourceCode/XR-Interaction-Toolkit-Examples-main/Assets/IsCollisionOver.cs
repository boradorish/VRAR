using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class IsCollisionOver : MonoBehaviour
{
    //random 배치 function에서 호출될 수 있는 public 변수
    public int socket_number = 0;
    public int object_number = 0;
    public int number_of_modified_objects = 1;

    //empty object인 score object를 불러올 변수
    //GameObject obj;

    public score obj;

    //
    GameObject[] sockets;
    GameObject[] objects;
    GameObject socket;
    GameObject chair;


    //
    private float dist;
    private float err = 0.01F;
    private int[] collisions_times = new int[1];//same with number_of_modified_objects


    // Start is called before the first frame update
    void Start()
    {
        //For several sockets and objects
        socket = GameObject.Find("ChairSocket");
        chair = GameObject.Find("Chair");

        //For 1 socket, 1 object
        sockets = GameObject.FindGameObjectsWithTag("sockets");
        objects = GameObject.FindGameObjectsWithTag("objects");

        //
        collisions_times = new int[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == sockets[socket_number].name && collisions_times[0] == 0)
        {
            dist = Vector3.Distance(sockets[socket_number].transform.position, objects[object_number].transform.position);
            //dist = Vector3.Distance(socket.transform.position, chair.transform.position);

            if(-err < dist && dist < err)
            {
                score.instance.getscore = true;
                //Debug.Log("IsCollision: same position checked");
                collisions_times[0]++;
            }
            else
            {
                //Debug.Log(dist);
            }
            //Debug.Log("IsCollision: Cube checked");
        }
        //Debug.Log("0: "+objects[object_number].name + " 1: "+ objects[object_number+1].name);
        //Debug.Log(sockets[socket_number].name);
        //Debug.Log("0: "+sockets[socket_number].name + " 1: "+ sockets[socket_number+1].name + " 2: "+sockets[socket_number+2].name);
    }
}
