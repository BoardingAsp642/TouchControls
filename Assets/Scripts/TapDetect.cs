using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetect : MonoBehaviour
{
    //Varaibles

    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            //If the touching just started and the touching was within the collider
            if(touch.phase == TouchPhase.Began && boxCollider.OverlapPoint(touchPos))
            {
                Destroy(gameObject);
            }
        }
    }
}
