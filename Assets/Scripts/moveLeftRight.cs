using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeftRight : MonoBehaviour
{

    //rightPos = the rightmost x position. leftPos = the leftmost x position
    public float moveSpeed = 5f, rightPos = 0f, leftPos = 0f;
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftPos)
        {
            moveRight = true;
        }
        if (transform.position.x > rightPos)
        {
            moveRight = false;
        }

        if(moveRight){
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
                transform.position.y);
        }else{
            transform.position =
                       new Vector2(transform.position.x - moveSpeed * Time.deltaTime,
                           transform.position.y);
        }
    }


}
