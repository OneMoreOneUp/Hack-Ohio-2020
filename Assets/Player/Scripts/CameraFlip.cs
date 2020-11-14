using UnityEngine;
using UnityStandardAssets._2D;

public class CameraFlip : MonoBehaviour
{
    public Transform m_Camera;
    public GameObject player;

    public void FlipCamera()
    {
        FlipSortOrder();
        player.GetComponent<Player2DCollision>().FlipSide();

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
