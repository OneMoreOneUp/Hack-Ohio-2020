using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == collision.gameObject.tag.Equals("Player"))
        {
            collision.collider.transform.SetParent(transform);

            collision.gameObject.GetComponent<PlatformerCharacter2D>().m_MaxSpeed = 60f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider == collision.gameObject.tag.Equals("Player"))
        {
            collision.collider.transform.SetParent(null);
            collision.gameObject.GetComponent<PlatformerCharacter2D>().m_MaxSpeed = 10f;
        }
    }


}
