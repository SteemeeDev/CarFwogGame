using UnityEngine;

public class MapPart : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Vector2 spriteSize;

    public void UpdateSpriteSize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.size * transform.localScale;
    }
}
