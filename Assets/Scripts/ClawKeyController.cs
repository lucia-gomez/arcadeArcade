using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClawKeyController : MonoBehaviour
{
    private Animator mAnimator;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isLowering = false;
    public float moveAmount = 20;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;
        rb = GetComponent <Rigidbody>();
    }

    private void FixedUpdate() 
    {
        if (!isLowering)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * moveAmount);
        }
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(mAnimator != null) {
            if(Input.GetKeyDown(KeyCode.Return)) {
                isLowering = true;
                mAnimator.SetTrigger("TrClawGrab");
                Invoke("TriggerSecondAnimation", 8f);
            }
        } 
    }

    void TriggerSecondAnimation()
    {
        // Trigger the second animation after 2 seconds
        mAnimator.SetTrigger("TrClawOpen");
        isLowering = false;
    }
}
