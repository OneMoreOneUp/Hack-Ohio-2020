using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Public integer to hold the speed of the rotation.
    public int speed = 45;

    // Update is called once per frame
    void Update()
    {
        //Set the sprite's rotation around the Z-axis by multiplying the Vector3, with a value of 45 for Z, by the deltaTime in order to make the rotation smooth and independent to the frame rate.
        transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
    }
}
