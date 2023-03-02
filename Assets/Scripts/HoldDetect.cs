using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDetect : MonoBehaviour
{    //Varaibles

    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;
    public bool isHolding = false;
    public float jumpForce;
    //Number of seconds of hold
    public float holdTime;

//Time before EVENT
    public float holdLimit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            //If the touching just started and the touching was within the collider
            if (touch.phase == TouchPhase.Began && boxCollider.OverlapPoint(touchPos))
            {
                //Set isHolding to true
                isHolding = true;
                //Reset Hold time
                holdTime = 0;
            }

            //if the touch is j=moving, move the object
            else if (touch.phase == TouchPhase.Stationary && isHolding)
            {
                holdTime += Time.deltaTime;

            }


            else if(touch.phase == TouchPhase.Ended && isHolding)
            {
                isHolding = false;
            }
            //when the hold time reaches limit launch the item
            if(holdTime >= holdLimit)
            {
                holdTime = 0;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }






        }
    }

}
