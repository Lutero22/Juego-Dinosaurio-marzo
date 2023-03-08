using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirSuelo : MonoBehaviour
{
    private float AnchoSprite;

    void Start()
    {
        BoxCollider2D ColliderSuelo = GetComponent<BoxCollider2D>();
        AnchoSprite = ColliderSuelo.size.x;
    }

    void Update()
    {
        if(transform.position.x < -AnchoSprite)
        {
            transform.Translate(Vector2.right * 2f * AnchoSprite);
        }
    }
}
