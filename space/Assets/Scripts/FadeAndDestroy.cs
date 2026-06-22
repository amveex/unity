using UnityEngine;

public class FadeAndDestroy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float duration = 0.5f;
    private float lifeTimer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lifeTimer = duration;
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
        else if (spriteRenderer != null)
        {
            Color currentVisualColor = spriteRenderer.color;
            currentVisualColor.a = lifeTimer / duration; 
            spriteRenderer.color = currentVisualColor;
        }
    }
}
