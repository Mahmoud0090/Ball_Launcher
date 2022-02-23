using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D currentBallRigidbody2D;
    [SerializeField] private SpringJoint2D currentBallSpringJoint2D;
    [SerializeField] float detachDelay;


    private Camera mainCamera;
    private bool isDragging;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBallRigidbody2D == null) { return; }

        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isDragging)
            {
                LaunchBall();
            }

            isDragging = false;

            return;
        }

        isDragging = true;

        currentBallRigidbody2D.isKinematic = true;

        Vector2 touchPosition =  Touchscreen.current.primaryTouch.position.ReadValue();

        Vector2 worldPostion = mainCamera.ScreenToWorldPoint(touchPosition);

        currentBallRigidbody2D.position = worldPostion;

    }

    private void LaunchBall()
    {
        currentBallRigidbody2D.isKinematic = false;
        currentBallRigidbody2D = null;

        Invoke(nameof(DetachTheBall), detachDelay);
    }

    private void DetachTheBall()
    {
        currentBallSpringJoint2D.enabled = false;
        currentBallSpringJoint2D = null;
    }
}
