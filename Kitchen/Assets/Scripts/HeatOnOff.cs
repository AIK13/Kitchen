using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatOnOff : MonoBehaviour 
{

	private int numTimesClicked;
	public bool heatOn;
	public Renderer rend;
	
	// Use this for initialization
	void Start () 
	{
		numTimesClicked = 0;
		heatOn = false;
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnMouseDown()
	{
		numTimesClicked += 1;
		
		if ((numTimesClicked % 2) == 0)
		{
			heatOn = false;
			rend.material.color = Color.white;
			// it's not just Renderer.material... because Renderer requires the game Object, and
			// for some reason, it can't just access the current game object... Oh well.
		}
		else
		{
			heatOn = true;
			rend.material.color = Color.red;
		}
	}
}
