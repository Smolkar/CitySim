using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour {

	// Here we store all the objects that we can place on the map
	public List<MapObjectBase> mapObjects;

//	private static ResourcesManager instance = null;

//	void Awake()
//	{
//		instance = this;
//	}
//
//	public static ResourcesManager GetInstance()
//	{
//		return instance;
//	}

	public ResourcesManager()
	{
		mapObjects = new List<MapObjectBase>();
	}

	public MapObjectBase GetObjectBase(string objId)
	{
		MapObjectBase retVal = null;

		for(int i = 0; i < mapObjects.Count; i++)
		{
			if(objId.Equals(mapObjects[i]))
			{
				retVal = mapObjects[i];
				break;
			}	
		}
		return retVal;
	}
}
