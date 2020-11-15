using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    public GameObject hand, white, canvas;
    public float xSpeed = 1, ySpeed = 1;
    private bool started = false;
    private RectTransform handRect, whiteRect, canvasRect;
    private int directionScalar = -1;

    public void Awake()
    {
        started = true;
        handRect = hand.GetComponent<RectTransform>();
        whiteRect = white.GetComponent<RectTransform>();
        canvasRect = canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            Transition();
        }
    }

    private void Transition()
    {
        MoveHand();
        MoveWhite();
        CheckDone();
    }

    private void MoveHand()
    {
        handRect.position += new Vector3(xSpeed * Time.deltaTime, directionScalar * ySpeed * Time.deltaTime, 0);
        SetYSclar();
    }

    private void SetYSclar()
    {
        Vector3[] handWorldCoords = new Vector3[4], whiteWorldCoords = new Vector3[4];
        handRect.GetWorldCorners(handWorldCoords);
        whiteRect.GetWorldCorners(whiteWorldCoords);
        float handTop = handWorldCoords[1].y, whiteTop = whiteWorldCoords[1].y, whiteBot = whiteWorldCoords[0].y, whiteHeight = whiteTop - whiteBot;

        if (handTop >= whiteTop) directionScalar = -1;
        else if (handTop <= whiteBot + (whiteHeight / 4)) directionScalar = 1;
    }

    private void MoveWhite()
    {
        whiteRect.position += new Vector3(xSpeed * Time.deltaTime, 0, 0);
    }

    private void CheckDone()
    {
        Vector3[] handWorldCoords = new Vector3[4], canvasWorldCoords = new Vector3[4];
        handRect.GetWorldCorners(handWorldCoords);
        canvasRect.GetWorldCorners(canvasWorldCoords);

        float handLeft = handWorldCoords[0].x, canvasRight = canvasWorldCoords[2].x;

        if (xSpeed == 0 || handLeft > canvasRight)
        {
            started = false;
            Destroy(hand);
            Destroy(white);
            Destroy(canvas);
        }
    }
}
