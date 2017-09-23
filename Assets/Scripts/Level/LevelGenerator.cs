using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public static LevelGenerator instance;
	//library of pieces to generate from
	public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
	public Transform levelStartPoint;
	//list of pieces currently in the level
	public List<LevelPiece> pieces = new List<LevelPiece>();

	void Awake() = {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPiece(){
		int randomIndex = Random.Range(0,levelPrefabs.Count);

		//create a copy of the above random piece
		LevelPiece newPiece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
		newPiece.transform.SetParent(this.transform, false);

		Vector3 spawnPosition = Vector3.zero;

		//set the position
		if (pieces.Count>0){
			spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
		} else {
			spawnPosition = levelStartPoint.position;
		}
	}
}
