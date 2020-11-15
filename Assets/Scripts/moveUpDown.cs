using UnityEngine;

public class moveUpDown : MonoBehaviour
{
    //highestPos = the highest y position. lowestPos = the lowest y position
    public float moveSpeed = 5f, highestPos = 0f, lowestPos = 0f, currentPos = 0f;
    bool moveUp = true;

    private void Start()
    {
        currentPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float newhighestPos = currentPos + highestPos, newlowestPos = currentPos - lowestPos;

        if (transform.position.y < newlowestPos)
        {
            moveUp = true;
        }
        if (transform.position.y > newhighestPos)
        {
            moveUp = false;
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x,
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
