using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {

	public string objId;
//	public float gridPosX;
//	public float gridPosZ;
	public Vector3 worldPositionOffset;
	public Vector3 worldRotation;

	public float rotateDegrees = 45;

	public void ChangeRotation()
	{
		Vector3 eulerAngles = transform.eulerAngles;
		eulerAngles += new Vector3(0, rotateDegrees, 0);
		transform.localRotation = Quaternion.Euler(eulerAngles);
	}

	public SavableMapObject GetSaveableObject()
	{
		SavableMapObject savedObj = new SavableMapObject();

		savedObj.objId = objId;
		savedObj.posX = transform.position.x;
		savedObj.posZ = transform.position.z;

		savedObj.rotX = transform.localEulerAngles.x;
		savedObj.rotY = transform.localEulerAngles.y;
		savedObj.rotZ = transform.localEulerAngles.z;

		return savedObj;
	}

}
