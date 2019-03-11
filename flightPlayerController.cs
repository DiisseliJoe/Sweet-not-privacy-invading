using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flightPlayerController : MonoBehaviour {
	public float speed;
	private Rigidbody2D myBody;
	private Transform myTransform;
	private float hInput;
	
	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D>();
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
        Move(Input.GetAxisRaw("Horizontal"));

        #else
        Move(hInput);
       	#endif
	}
	void Move(float horizontalInput)
    {
			
			Vector2 moveVel = myBody.velocity;
			moveVel.x = horizontalInput * speed;
			myBody.velocity = moveVel;
            Vector2 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, -7, 7);
            transform.position = clampedPosition;
            
    }

	public void StartMoving(float horizontalInput)
	{

			hInput = horizontalInput;
            Vector2 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(transform.position.x, -7, 7);
            transform.position = clampedPosition;
    }

}
