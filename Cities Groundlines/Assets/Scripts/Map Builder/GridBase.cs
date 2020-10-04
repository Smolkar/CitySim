using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBase : MonoBehaviour {

	private GameObject nodePrefab;

	public int _sizeX; 
	public int _sizeZ; 
	public int _offset;

//	public Node [,] grid;

	public GameObject [,] nodeGrid;


	private static GridBase instance = null;

	public GridBase(int x, int z, int offset, GameObject prefab)
	{
		_sizeX = x;
		_sizeZ = z;
		_offset = offset;
		nodePrefab = prefab;

		CreateGrid();
	}
//	public static GridBase GetInstance()
//	{
//		return instance;
//	}
//
//	void Awake()
//	{
//		instance = this;
//		CreateGrid();
//		//CreateMouseCollision();
//	}

	void CreateGrid(){
		nodeGrid = new GameObject[_sizeX, _sizeZ];

		for (int x = 0; x < _sizeX; x++)
		{
			for (int z = 0; z < _sizeZ; z++){
				
				float posX = x * _offset;
				float posZ = z * _offset;

				GameObject go = Instantiate(nodePrefab, new Vector3(posX, 0, posZ), Quaternion.identity) as GameObject;

				nodeGrid[x,z] = go;
			}	
		}
	}

	// TODO: Test if it works like it should
	public GameObject NodeFromWorldPosition(Vector3 worldPosition)
	{
		float worldX = worldPosition.x;
		float worldZ = worldPosition.z;

		worldX /= _offset;
		worldZ /= _offset;

		Transform nodeTransform = nodePrefab.GetComponent<Transform>();

		float xScale = nodeTransform.localScale.x;
		float zScale = nodeTransform.localScale.z;

		int x = Mathf.RoundToInt(worldX/xScale);
		int z = Mathf.RoundToInt(worldZ/zScale);

		Debug.Log("X: " + x + "  Z: " + z);

		return nodeGrid[x,z];

	}
}
