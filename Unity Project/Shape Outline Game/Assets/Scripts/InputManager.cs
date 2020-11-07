using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	private Vector2 mousePos;
	private Vector2 prevMousePos;

	public GameObject line;
	private LineRenderer currentLine;
	private List<Vector3> points;

	// Use this for initialization
	void Start()
	{
		points = new List<Vector3>();
		InvokeRepeating("HandleInput", 1f, .05f);
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			GameObject l = Instantiate(line, transform.position, Quaternion.identity) as GameObject;
			currentLine = l.GetComponent<LineRenderer>();
			points.Clear();
		}
	}

	private void HandleInput()
	{
		mousePos = Input.mousePosition;

		if(Input.GetMouseButton(0) && (mousePos != prevMousePos))
		{
			points.Add(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f)));
			currentLine.positionCount = points.Count;
			currentLine.SetPosition(points.Count - 1, points[points.Count - 1]);
		}

		prevMousePos = mousePos;
	}
}
