using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float VelocidadScroll = 8f;

    void Update()
    {
        transform.Translate(Vector2.left * VelocidadScroll * Time.deltaTime);
    }
}
