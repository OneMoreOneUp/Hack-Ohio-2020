using UnityEngine;

public class LevelOutro : MonoBehaviour
{
    public GameObject hand, white, canvas;
    public float xSpeed = 1, ySpeed = 1;
    private bool started = false;
    private RectTransform handRect, whiteRect, canvasRect;
    private int directionScalar = -1;
    public LoadScene sceneLoader;
    public AudioSource eraseSound;

    public void OnTriggerEnter2D(Collider2D other)
    {
        started = true;
        EnableWipe();
        handRect = hand.GetComponent<RectTransform>();
        whiteRect = white.GetComponent<RectTransform>();
        canvasRect = canvas.GetComponent<RectTransform>();
        eraseSound.Play();
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

        float handRight = handWorldCoords[2].x, canvasLeft = canvasWorldCoords[0].x;

        if (xSpeed == 0 || canvasLeft > handRight)
        {
            started = false;
            sceneLoader.LoadNext();
            eraseSound.Stop();
        }
    }
}
