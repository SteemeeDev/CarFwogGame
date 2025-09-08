using UnityEngine;

public class MapPart : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Vector2 spriteSize;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.size * transform.localScale;
    }
}
