using UnityEngine;

public class moveLeftRight : MonoBehaviour
{

    //rightPos = the rightmost x position. leftPos = the leftmost x position


    public float moveSpeed = 5f, rightPos = 0f, leftPos = 0f, currentPos = 0;

    bool moveRight = true;

    private void Awake()
    {
        currentPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float newRightPos = currentPos + rightPos, newLeftPos = currentPos - leftPos;

        if (transform.position.x < newLeftPos)
        {
            moveRight = true;

        }
        if (transform.position.x > newRightPos)
        {
            moveRight = false;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
                transform.position.y);
        }
        else
        {
            transform.position =
                       new Vector2(transform.position.x - moveSpeed * Time.deltaTime,
                           transform.position.y);
        }
    }
}
