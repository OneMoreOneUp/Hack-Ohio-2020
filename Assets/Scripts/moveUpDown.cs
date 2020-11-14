using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUpDown : MonoBehaviour
{
    //highestPos = the highest y position. lowestPos = the lowest y position
    public float moveSpeed = 5f, highestPos = 0, lowestPos = 0; 
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lowestPos)
        {
            moveRight = true;
        }
        if (transform.position.y > highestPos)
        {
            moveRight = false;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x ,
                transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position =
                       new Vector2(transform.position.x,
                           transform.position.y - moveSpeed * Time.deltaTime);
        }
    }


}
