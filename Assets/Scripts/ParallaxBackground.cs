using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Vector2 parallaxMul;
    [SerializeField]
    private bool
        infiniteHorizontal,
        infiniteVertical;

    private Transform camTransform;

    private Vector3 lastCamPos;

    private float textureUnitSizeX;
    private float textureUnitSizeY;

    private void Start()
    {
        camTransform = Camera.main.transform;
        lastCamPos = camTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;   
    }

    private void FixedUpdate()
    {
        Vector3 delatMove = camTransform.position - lastCamPos;      
        transform.position += new Vector3(delatMove.x * parallaxMul.x, delatMove.y * parallaxMul.y);
        lastCamPos = camTransform.position;

        if(infiniteHorizontal)
        {
            if (Mathf.Abs(camTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetPosX = (camTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(camTransform.position.x + offsetPosX, transform.position.y);
            }
        }

        if(infiniteVertical)
        {
            if (Mathf.Abs(camTransform.position.y - transform.position.y) >= textureUnitSizeX)
            {
                float offsetPosY = (camTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, camTransform.position.y + offsetPosY);
            }
        }
    }
}
