using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    private int desiredLane = 1;

    public float laneDistance = 4;
    public float forwardSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (!PlayerManager.isRunning)
            return;

        // Game has three lanes and when you swipe to left or right, the player moves.
        if (SwipeManager.swipeRight)
        {
            desiredLane++;

            if(desiredLane == 3)
                desiredLane = 2;
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;

            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        } else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
        controller.Move(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }

}
