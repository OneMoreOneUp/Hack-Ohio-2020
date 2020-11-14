using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Player2DCollision : MonoBehaviour
{
    public ParticleSystem bloodSplatter;
    private enum Sides {A, B};
    private Sides side;

    private void Awake()
    {
        side = Sides.A;
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 10, true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Trap")) Die();
    }

    private void Die()
    {
        bloodSplatter.transform.position = transform.position;
        bloodSplatter.Play();
        GetComponent<SpriteRenderer>().enabled = false; //Hide body
        GetComponent<Platformer2DUserControl>().enabled = false;
    }

    public void FlipSide()
    {
        if(side == Sides.A)
        {
            side = Sides.B;
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Physics2D.IgnoreLayerCollision(8, 10, false);
        }
        else
        {
            side = Sides.A;
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
    }
}
