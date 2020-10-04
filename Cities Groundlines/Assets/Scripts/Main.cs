using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	public int SizeXOfMap = 0;
	public int SizeZOfMap = 0;
	public int Offset = 0;
	public GameObject nodePrefab;
	public GameObject objectToPlace;

	private ResourcesManager resourcesManager;

	private GridBase gridBase;

	private ObjectPlacer objectPlacer;


	void Start () {
		resourcesManager = new ResourcesManager();
		gridBase = new GridBase(SizeXOfMap, SizeZOfMap, Offset, nodePrefab);
		objectPlacer = new ObjectPlacer(gridBase, resourcesManager, objectToPlace);
		
	}


	void Update () {
		objectPlacer.TryPlaceAnObject();
	}
}
