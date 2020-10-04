using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour {

	GridBase gridBase;
	ResourcesManager resourceManager;

	#region Place object variables

	bool hasObj = true; // just for the testing
	GameObject objToPlace; // --------
	GameObject cloneObj;
	MapObject objProperties;
	Vector3 mousePosition;
	Vector3 selectedNodePosition;
	bool deleteObj;

	#endregion

	public ObjectPlacer(GridBase gBase, ResourcesManager resManager, GameObject objectToPlace)
	{
		gridBase = gBase;
		objToPlace = objectToPlace;
		resourceManager = resManager;
	}
//	void Start()
//	{
//		gridBase = GridBase.GetInstance();
//	}
//
//	void Update()
//	{
//		TryPlaceAnObject();
//	}

	#region Place Objects

	public void TryPlaceAnObject()
	{
		if(hasObj)
		{
			UpdateMousePosition();

			GameObject selectedNode = gridBase.NodeFromWorldPosition(mousePosition);

			//selectedNodePosition = selectedNode.nodeObject.transform.position;
			selectedNodePosition = selectedNode.transform.position;


			if(cloneObj == null)
			{
				cloneObj = Instantiate(objToPlace, selectedNodePosition, Quaternion.identity) as GameObject;
				objProperties = cloneObj.GetComponent<MapObject>();	
			}else
			{
				cloneObj.transform.position = selectedNodePosition;

				if(Input.GetMouseButton(0)) // placing object
				{
					if(selectedNode != null)
					{
						//TODO: GUI warning that object cannot be placed here 
					}

					GameObject objPlaced = Instantiate(objToPlace, selectedNodePosition, cloneObj.transform.rotation) as GameObject;
					selectedNode.GetComponent<Node>().placedObj = objPlaced;
					//MapObject objPlacedProperties = objPlaced.GetComponent<MapObject>();
				}

				if(Input.GetKey(KeyCode.R)) // rotate object
				{
					objProperties.ChangeRotation();
				}
			}

		}
	}

	void UpdateMousePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			mousePosition = hit.point;
		}
	}

	public void SelectGameObjectToPlace(string objId)
	{
		if(cloneObj != null)
		{
			Destroy(cloneObj);
			cloneObj = null;
		}

		hasObj = true;
		//objToPlace = ResourcesManager.GetInstance().GetObjectBase(objId).objPrefab;
		objToPlace = resourceManager.GetObjectBase(objId).objPrefab;

	}

	#endregion

}
