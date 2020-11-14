using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeftRight : MonoBehaviour
{

    float moveSpeed = 4f, endPos = -10f, startPos = -17f;
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < endPos)
        {
            moveRight = true;
        }
        if (transform.position.x > startPos)
        {
            moveRight = false;
            startPos = -10f;
            endPos = -17f;
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
