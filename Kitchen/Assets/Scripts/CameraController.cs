using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
	 public GameObject player;
	 private Camera mycam;
	 private Vector3 offset;
	 
	 void Start()
	{
		mycam = GetComponent<Camera>();
		offset = transform.position - player.transform.position;
	}
	 
	 void LateUpdate()
	{
		//rotation
		float sensitivity = 0.05f;
		Vector3 vp = mycam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane));
		vp.x -= 0.5f;
		vp.y -= 0.5f;
		vp.x *= sensitivity;
		vp.y *= sensitivity;
		vp.x += 0.5f;
		vp.y += 0.5f;
		Vector3 sp = mycam.ViewportToScreenPoint(vp);
		 
		Vector3 v = mycam.ScreenToWorldPoint(sp);
		transform.LookAt(v, Vector3.up);
		 
		//transform.LookAt (mycam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane)), Vector3.up);
	
		// movement
		transform.position = player.transform.position + offset;
	}
	
}

// this is good code to look at for ideas later.
   /* public GameObject player;

    private Vector3 offset;
	private Vector3 offsetR;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
		//offsetR = transform.rotation - player.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
		//transform.rotation = player.rotation + offsetR;
	}*/
	
	/*
	[SerializeField]
     private Transform target;
 
     [SerializeField]
     private Vector3 offsetPosition;
 
     [SerializeField]
     private Space offsetPositionSpace = Space.Self;
 
     [SerializeField]
     private bool lookAt = true;
 
     private void Update()
     {
         Refresh();
     }
 
     public void Refresh()
     {
         if(target == null)
         {
             Debug.LogWarning("Missing target ref !", this);
 
             return;
         }
 
         // compute position
         if(offsetPositionSpace == Space.Self)
         {
             transform.position = target.TransformPoint(offsetPosition);
         }
         else
         {
             transform.position = target.position + offsetPosition;
         }
 
         // compute rotation
         if(lookAt)
         {
             transform.LookAt(target);
         }
         else
         {
             transform.rotation = target.rotation;
         }
     }*/