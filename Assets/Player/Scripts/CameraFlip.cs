using UnityEngine;
using UnityStandardAssets._2D;

public class CameraFlip : MonoBehaviour
{
    public Transform m_Camera;
    public GameObject player;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            FlipCamera();
            ChangePlayerLayer();
            FlipSortOrder();
            player.GetComponent<Platformer2DUserControl>().InvertHorizontal();
        }
    }

    private void FlipCamera()
    {
        m_Camera.transform.eulerAngles -= new Vector3(0, 180, 0);

        if(m_Camera.position.z > 0)
        {
            m_Camera.position -= new Vector3(0, 0, 20);
        }
        else
        {
            m_Camera.position += new Vector3(0, 0, 20);
        }
    }

    private void ChangePlayerLayer()
    {
        if(player.layer == 9)
        {
            player.layer = 10;
        }
        else if (player.layer == 10)
        {
            player.layer = 9;
        }
        else
        {
            Debug.LogError("[Error] Unable to change player layer.");
        }
    }

    private void FlipSortOrder()
    {
        foreach(SpriteRenderer renderer in FindObjectsOfType<SpriteRenderer>())
        {
            if(renderer.sortingLayerName == "SideA")
            {
                renderer.sortingLayerName = "SideB";
            }
            else if (renderer.sortingLayerName == "SideB")
            {
                renderer.sortingLayerName = "SideA";
            }
        }
    }
}
