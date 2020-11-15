using UnityEngine;

public class LayerFlip : MonoBehaviour
{
    public Transform m_Camera;
    public GameObject player, parentA, parentB;

    public void FlipCamera()
    {
        FlipSortOrder(parentA);
        FlipSortOrder(parentB);
        player.GetComponent<Player2DCollision>().FlipSide();
    }

    private void FlipSortOrder(GameObject parent)
    {
        foreach (SpriteRenderer renderer in parent.GetComponentsInChildren<SpriteRenderer>())
        {
            if (renderer.sortingLayerName == "SideA")
            {
                renderer.sortingLayerName = "SideB";
            }
            else if (renderer.sortingLayerName == "SideB")
            {
                renderer.sortingLayerName = "SideA";
            }
        }
    }

    private void Awake()
    {
        SetSortOrder();
    }

    public void SetSortOrder()
    {
        foreach (SpriteRenderer renderer in parentA.GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.sortingLayerName = "SideA";
            renderer.gameObject.layer = 9;
        }

        foreach (SpriteRenderer renderer in parentB.GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.sortingLayerName = "SideB";
            renderer.gameObject.layer = 10;
        }
    }
}
