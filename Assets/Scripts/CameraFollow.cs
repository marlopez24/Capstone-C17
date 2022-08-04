using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }
    

    // LAteUpdate is called once everything in update is ran
    void LateUpdate()
    {
        // in a void function when you use return statement, it won't execute any code down below
        //if the it is true, like if there is no more playerr then  it will just return 
        if (!player)
            return;

        tempPos = transform.position;
        tempPos.x = player.position.x;


        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

            transform.position = tempPos;
    }
} // class
