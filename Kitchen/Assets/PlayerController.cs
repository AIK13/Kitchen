using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public GameObject PlayerCamera;
	//public GameObject thisPlayer; // this is unnecessary
	
    public float speed;

    private Rigidbody rb;
	private int count;
	public float turningSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
		
		//https://docs.unity3d.com/ScriptReference/RigidbodyConstraints.FreezePositionY.html 
		// freezing transform y, and rotation x and z
		rb.constraints = RigidbodyConstraints.FreezePositionY;
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // fixed update performed just before physics calculations
    // This is where the physics code should go
    // We're moving a ball by applying forces to rigidBody: physics.
    private void FixedUpdate()
    {
        // input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		
		// matching the rotation of the camera and the darn object.
		//transform.Rotate(0.0f, PlayerCamera.transform.eulerAngles.y, 0.0f); // makes the character spin uncontrollably...
		// though the player can't see this. 
		
		// https://answers.unity.com/questions/910255/rotate-player-on-y-axis-with-mouse.html 
		Quaternion CharacterRotation = PlayerCamera.transform.rotation;
		CharacterRotation.x = 0;
		CharacterRotation.z = 0;
		
		transform.rotation = CharacterRotation;
		// oh my... this actually works...! Except if I run into something really hard. Then it clips, but it resets nicely.
		
		
		/*// rotation https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html 
		// get screen position of the object
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		
		// get screen position of the mouse-location
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		
		// get angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		
		// yay
		transform.rotation = Quaternion.Euler (new Vector3(0f,angle*turningSpeed,0f));
		*/
		
        // forces on RigidBody
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
		
		
    }

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
	
	
	
	//public float RotateSpeed;
	//public Text countText;
	//public Text winText;
	
	// in start
	//count = 0;
		//SetCountText ();
		//winText.text = "";
		
	// in fixedupdate
	// rotating attempt 1
		/*if (Input.GetAxis("Mouse X") < 0)
			transform.Rotate(Vector3.up) * RotateSpeed;
		if (Input.GetAxis("Mouse X") > 0)
			transform.Rotate(Vector3.up) * -RotateSpeed.
		*/
	
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive(false);
			count = count + 1;
			//SetCountText ();
        }
    }*/
	
	/*void SetCountText ()
	{
		countText.text = "Count: " + count.ToString();
		
		if (count >= 13)
		{
			winText.text = "You Win! Yaaay~";
		}
	}*/

}
