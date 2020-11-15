using UnityEngine;

public class BloodSplat : MonoBehaviour
{
    public float minSize = 0.8f;
    public float maxSize = 1.5f;

    public Sprite[] sprites;
    public GameObject player;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize()
    {
        RandomizeSplat();
        MaskSplat();
    }

    private void RandomizeSplat()
    {
        //Randomly pick sprite
        int spriteIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[spriteIndex];

        //Randomly pick size (between min and max size)
        float size = Random.Range(minSize, maxSize);
        transform.localScale *= size;

        //Randomly pick rotation
        float rotation = Random.Range(-360f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }

    private void MaskSplat()
    {
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        spriteRenderer.sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder;
        gameObject.layer = player.layer;
    }
}
