using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropShadow : MonoBehaviour
{
    public Vector2 ShadowOffset = new Vector2(-0.1f, -0.1f);
    public Material ShadowMaterial;

    SpriteRenderer spriteRenderer;
    GameObject shadowGameobject;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //create a new gameobject to be used as drop shadow
        shadowGameobject = new GameObject("Shadow");
        DontDestroyOnLoad(shadowGameobject);
        shadowGameobject.transform.SetParent(gameObject.transform);
        shadowGameobject.transform.localPosition = new Vector3(0,0,0) + (Vector3)ShadowOffset;
        //create a new SpriteRenderer for Shadow gameobject
        SpriteRenderer shadowSpriteRenderer = shadowGameobject.AddComponent<SpriteRenderer>();

        //set the shadow gameobject's sprite to the original sprite
        shadowSpriteRenderer.sprite = spriteRenderer.sprite;
        //set the shadow gameobject's material to the shadow material we created
        shadowSpriteRenderer.material = ShadowMaterial;

        //update the sorting layer of the shadow to always lie behind the sprite
        shadowSpriteRenderer.sortingLayerName = spriteRenderer.sortingLayerName;
        shadowSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder - 1;
        shadowGameobject.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        
    }

    void LateUpdate()
    {
        //update the position and rotation of the sprite's shadow with moving sprite
        //shadowGameobject.transform.localPosition = transform.localPosition + (Vector3)ShadowOffset;
        //shadowGameobject.transform.localRotation = transform.localRotation;
    }
}