using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour {
    public Rigidbody2D rb;
    public float tr = 0.3f;
    private bool isPressed = false;

    void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

    }   
}
