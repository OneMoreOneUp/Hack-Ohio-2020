using UnityEngine;
using UnityStandardAssets._2D;

public class Player2DCollision : MonoBehaviour
{
    public ParticleSystem bloodSplatter;
    public Transform respawn;
    public AudioSource bloodSplat;
    private Vector3 deathPos;

    public enum Sides { A, B };
    public Sides side;
    private bool isDead = false;

    private void Awake()
    {
        side = Sides.A;
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 10, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isDead) Die();
            Revive();
        }
        else if (isDead)
        {
            transform.position = deathPos;
        }
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
        GetComponent<PlatformerCharacter2D>().enabled = false;
        isDead = true;
        deathPos = transform.position;
        bloodSplat.Play();
    }

    private void Revive()
    {
        transform.position = respawn.position;
        transform.rotation = new Quaternion();
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Platformer2DUserControl>().enabled = true;
        GetComponent<PlatformerCharacter2D>().enabled = true;
        isDead = false;
    }

    public void FlipSide()
    {
        if (side == Sides.A)
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
