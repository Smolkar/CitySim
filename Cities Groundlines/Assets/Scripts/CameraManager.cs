using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {


	public float topBorder;
	public float bottomBorder;
	public float leftBorder;
	public float rightBorder;
	public float scrollSpeed;


	// Update is called once per frame
	void Update () {

		if(Input.mousePosition.y >= Screen.height * topBorder)
		{
			transform.Translate(Vector3.up * Time.deltaTime * scrollSpeed);
		}

		if(Input.mousePosition.y <= Screen.height * bottomBorder)
		{
			transform.Translate(Vector3.down * Time.deltaTime * scrollSpeed);
		}

		if(Input.mousePosition.x >= Screen.width * rightBorder)
		{
			transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed);
		}

		if(Input.mousePosition.x <= Screen.width * leftBorder)
		{
			transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed);
		}
	}
}
