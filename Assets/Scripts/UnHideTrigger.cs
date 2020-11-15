using UnityEngine;

public class UnHideTrigger : MonoBehaviour
{
    public GameObject[] objects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
