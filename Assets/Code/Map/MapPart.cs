using UnityEngine;
using UnityEngine.Windows.Speech;

public class MapPart : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Vector2 spriteSize;

    public GameObject[] validMapParts;

    private void Start()
    {
        UpdateSpriteSize();
    }

    public void UpdateSpriteSize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = new Vector2(spriteRenderer.sprite.textureRect.x, spriteRenderer.sprite.textureRect.y) * spriteRenderer.sprite.pixelsPerUnit * transform.localScale - Vector2.one * 2; 
        //Minus 2 because for some reason the calculated sprite size is 1 bigger in every dimension
    }
}
