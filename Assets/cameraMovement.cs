using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public static GameObject player;
    private Vector3 pos;
    public static Vector3 offset;
    public static bool callfunc=false;
    public static bool Camera = false;
    private bool xAxis = false;
    private GameObject lastObject;


    void changeoffset()
    {
        offset = transform.position - player.transform.position+Vector3.right/10;
        offset.y = 0;
    }
    void Start()
    {
        player = GameObject.Find("Bird");
        offset = transform.position - player.transform.position;
        offset.y = 0;
        lastObject = GameObject.Find("Domino (8)");
    }
    void Update()
    {
        if (callfunc)
        {
            changeoffset();
            callfunc = false;
        }
        if (sphere.move)
        {
            pos = player.transform.position;
            pos.y = 0;
            transform.position = pos + offset ;
        }
        if (player.name == "Domino (4)" || xAxis)
        {
            sphere.move = false;
            xAxis = true;
            Vector3 x = transform.position;
            transform.position = x + Vector3.right / 12;
            if (transform.position.x > lastObject.transform.position.x) 
            {
                sphere.move = true;
                callfunc = true;
                xAxis = false;

            }
        }

    }

}
