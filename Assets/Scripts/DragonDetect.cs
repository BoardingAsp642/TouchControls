using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDetect : MonoBehaviour
{
    //Varaibles

    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;
    public bool isDragging = false;

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
                //Set isDragging to true
                isDragging = true;
                // Make it Kinematic
                rb.isKinematic = true;
                // Stop the velocity
                rb.velocity = Vector2.zero;
            }

            //if the touch is j=moving, move the object
            else if(touch.phase == TouchPhase.Moved && isDragging)
            {
                gameObject.transform.position = touchPos;
            }
            //When you release the touch make it kinematicn't again
            else if(touch.phase == TouchPhase.Ended && isDragging)
            {
                //Make it not drag
                isDragging = false;
                //Make it not Kinematic
                rb.isKinematic = false;
            }






        }
    }

}
