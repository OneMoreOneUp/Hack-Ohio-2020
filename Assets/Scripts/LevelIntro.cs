using UnityEngine;

public class LevelIntro : MonoBehaviour
{
    public GameObject hand, white, canvas;
    public float xSpeed = 1, ySpeed = 1;
    private bool started = false;
    private RectTransform handRect, whiteRect, canvasRect;
    private int directionScalar = -1;
    public AudioSource scribbleSound;

    public void Awake()
    {
        EnableWipe();
        started = true;
        handRect = hand.GetComponent<RectTransform>();
        whiteRect = white.GetComponent<RectTransform>();
        canvasRect = canvas.GetComponent<RectTransform>();
        scribbleSound.Play();
    }

    public void EnableWipe()
    {
        canvas.SetActive(true);
        white.SetActive(true);
        hand.SetActive(true);
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
        MoveWhite();
        CheckDone();
    }

    private void MoveWhite()
    {
        whiteRect.position += new Vector3(xSpeed * Time.deltaTime, directionScalar * ySpeed * Time.deltaTime, 0);
        SetYSclar();
    }

    private void SetYSclar()
    {
        Vector3[] handWorldCoords = new Vector3[4], canvasWorldCoords = new Vector3[4];
        handRect.GetWorldCorners(handWorldCoords);
        canvasRect.GetWorldCorners(canvasWorldCoords);
        float handTop = handWorldCoords[1].y, canvasTop = canvasWorldCoords[1].y, canvasBot = canvasWorldCoords[0].y, canvasHeight = canvasTop - canvasBot;

        if (handTop >= canvasTop) directionScalar = -1;
        else if (handTop <= canvasBot + (canvasHeight / 4)) directionScalar = 1;
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
            scribbleSound.Stop();
        }
    }
}
