using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite normalSprite;

    [SerializeField]
    private Sprite hitSprite;

    [SerializeField]
    private float hitDuration = 0.2f;

    private float hitTimer = 0f;

    private void Start()
    {
        spriteRenderer.sprite = normalSprite;
    }

    void Update()
    {
        if (hitTimer > 0f)
        {
            hitTimer -= Time.unscaledDeltaTime;

            if (hitTimer <= 0f)
            {
                spriteRenderer.sprite = normalSprite;
            }
        }
    }

    public void UpdateDirection(float input)
    {
        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void PlayHitEffect()
    {
        spriteRenderer.sprite = hitSprite;
        hitTimer = hitDuration;
    }
}