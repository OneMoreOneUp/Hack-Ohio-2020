using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown : MonoBehaviour
{
    //startPos = the lowest y position. endPos = the highest y position
    float moveSpeed = 4f, endPos = 7, startPos = 0; 
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < endPos)
        {
            moveRight = true;
        }
        if (transform.position.y > startPos)
        {
            moveRight = false;
            //switch values of the above startPos & endPos
            startPos = 7;
            endPos = 0;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x ,
                transform.position.y+ moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position =
                       new Vector2(transform.position.x,
                           transform.position.y- moveSpeed * Time.deltaTime);
        }
    }


}
