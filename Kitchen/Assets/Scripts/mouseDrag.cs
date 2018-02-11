using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour 
{
	// using code from here https://www.youtube.com/watch?v=pK1CbnE2VsI
	float distance = 0.5f;
	
	void OnMouseDrag()
	{
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		
		transform.position = objPosition;
	}
	
	// will add nicer falling mechanics later, with OnMouseUp or something
}
