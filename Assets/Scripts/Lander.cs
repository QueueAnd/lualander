using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Lander : MonoBehaviour
{

    private Rigidbody2D landerRigidbody2D;
    private void Awake()
    {
            landerRigidbody2D=GetComponent<Rigidbody2D>();
            Debug.Log(Vector2.Dot(new Vector2(0,1), new Vector2(0,1)));
            Debug.Log(Vector2.Dot(new Vector2(0,1), new Vector2(.5f, .5f)));
            Debug.Log(Vector2.Dot(new Vector2(0,1), new Vector2(0,-1)));
    }
    private void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            float force=700f;
            landerRigidbody2D.AddForce(force*transform.up*Time.deltaTime);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            float turnSpeed=+100f;
            landerRigidbody2D.AddTorque(turnSpeed*Time.deltaTime);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            float turnSpeed=-100f;
            landerRigidbody2D.AddTorque(turnSpeed*Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        float softLandingMagnitude=4f;
        if (collision2D.relativeVelocity.magnitude > softLandingMagnitude)
        {
            Debug.Log("Crash");
            return;
        }

        float dotVector=Vector2.Dot(Vector2.up, transform.up);
        float minDotVector=0.9f;
        if (dotVector < minDotVector)
        {
            Debug.Log("Steep crash");
            return;
        }
        Debug.Log("Successful landing");

    }
}
