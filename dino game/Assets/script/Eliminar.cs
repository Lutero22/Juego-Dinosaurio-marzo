using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliminar : MonoBehaviour
{
    private float AnchoSprite;

    void Start()
    {
        CapsuleCollider2D ColliderSuelo = GetComponent<CapsuleCollider2D>();
        AnchoSprite = ColliderSuelo.size.x;
    }

    void Update()
    {
        if (transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
    }
}

