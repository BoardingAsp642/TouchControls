using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetect : MonoBehaviour
{//Varaibles

    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;
    public bool isSwipping = false;
    public float jumpForce;
    public Vector2 startPos;
    public Vector2 endPos;
    public Vector2 swipeVector;
    public float swipeMin;
    public float moveForce;



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
                isSwipping = true;
                startPos = touchPos;
                
            }




            else if (touch.phase == TouchPhase.Ended && isSwipping)
            {
                isSwipping = false;
                endPos = touchPos;
                Swipe();


            }
            //when the hold time reaches limit launch the item

            






        }
    }
 public void Swipe()
    {
        swipeVector = endPos - startPos;
        if(swipeVector.magnitude >= swipeMin)
        {
            //Check for Hor vs. Vert
            // if |x| > |y| then it is horizontal
            if(Mathf.Abs(swipeVector.x)>Mathf.Abs(swipeVector.y))
            {
                //Hor

                //if x is positive then swipe right
                if(swipeVector.x>0)
                {
                    rb.AddForce(Vector2.right * moveForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                //Ver
                rb.AddForce(Vector2.left * moveForce, ForceMode2D.Impulse);
            }
        }
        if (swipeVector.magnitude >= swipeMin)
        {
            //Check for Hor vs. Vert
            // if |x| > |y| then it is horizontal
            if (Mathf.Abs(swipeVector.x) > Mathf.Abs(swipeVector.y))
            {
                //Hor

                //if x is positive then swipe right
                if (swipeVector.y > 0)
                {
                    rb.AddForce(Vector2.right * moveForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                //Ver
                rb.AddForce(Vector2.left * moveForce, ForceMode2D.Impulse);
            }
        }
    }
}
