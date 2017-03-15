using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public GameObject arrowPrefab;
	public GameObject swoopPrefab;
	public GameObject goosePrefab;
	public GameObject skaterPrefab;
	//public GameObject boomerangPrefab;
	public GameObject rushPrefab;
	public GameObject stalkerPrefab;
	//public GameObject rafflesiaPrefab;
	public float xmax;
	public float xmin;
	public float ymin;
	public float ymax;

	private float gooseX1;
	private float gooseX2;
	private float gooseY;
	//private Vector3 rafflesiaSpawnPosition;

	Vector3 arrowSpawnPosition;
	Vector3 swoopSpawnPosition;
	Vector3 stalkerSpawnPosition;
	//Vector3 boomerangSpawnPosition;
	Vector3 gooseStartSpawnPosition;
	Vector3 gooseSecondaryPosition;

	float positionIndicator;
	float swoopRealPosition;
	float screenEdge = 2f;

	//initializes
	void Start () {
		//defines edges as camera points
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3 (1, 1, distance));

		//defines boundaries for the spawner
		xmin = leftEdge.x + screenEdge;
		xmax = rightEdge.x + screenEdge;
		ymin = leftEdge.y + 0.5f;
		ymax = rightEdge.y - 0.5f;
	}

	//spawns a "Arrow" type enemy at the position given
	public void SpawnArrow (Vector3 arrowSpawnPosition) {
		//spawns the enemy at the position given
		Debug.Log ("Arrow spawned");
		Instantiate (arrowPrefab, arrowSpawnPosition, Quaternion.identity, gameObject.transform);
	}
		
	//spawns a "Swoop" type enemy based on a true/false value
	public void SpawnSwoop (bool swoopSpawnTop) {
		//sets the spawn position based on a bool
		if (swoopSpawnTop == true) {
			swoopSpawnPosition = new Vector3 (xmax, ymax);
		} else {
			swoopSpawnPosition = new Vector3 (xmax, ymin);
		}

		//spawns the enemy at the determined position 
		Debug.Log ("Swoop spawned");
		Instantiate (swoopPrefab, swoopSpawnPosition, Quaternion.identity, gameObject.transform);
	}

	//spawns 5 "Goose" type enemies, based on a single point given
	public void SpawnGeese (Vector3 gooseStartSpawnPosition) {
		Debug.Log ("Flock spawned");
		//sets the possible x-values
		gooseX1 = xmax + 1;
		gooseX2 = xmax + 2;
		//makes the first enemy
		Instantiate (goosePrefab, gooseStartSpawnPosition, Quaternion.identity, gameObject.transform);

		//changes the y position for the new enemy, creates a new position, instantiates enemy, repeats
		gooseY = gooseStartSpawnPosition.y + 2f;
		gooseSecondaryPosition = new Vector3 (gooseX1, gooseY);
		Instantiate (goosePrefab, gooseSecondaryPosition, Quaternion.identity, gameObject.transform);
		gooseY = gooseStartSpawnPosition.y - 2f;
		gooseSecondaryPosition = new Vector3 (gooseX1, gooseY);
		Instantiate (goosePrefab, gooseSecondaryPosition, Quaternion.identity, gameObject.transform);
		gooseY = gooseStartSpawnPosition.y + 4f;
		gooseSecondaryPosition = new Vector3 (gooseX2, gooseY);
		Instantiate (goosePrefab, gooseSecondaryPosition, Quaternion.identity, gameObject.transform);
		gooseY = gooseStartSpawnPosition.y - 4f;
		gooseSecondaryPosition = new Vector3 (gooseX2, gooseY);
		Instantiate (goosePrefab, gooseSecondaryPosition, Quaternion.identity, gameObject.transform);
	}

	//spawns a "Skater" type enemy at a given starting point
	public void SpawnSkater (Vector3 skaterSpawnPosition, bool skaterStartUpwards) {
		//makes the enemy at the position given, gives the just-spawned enemy its vertical movement value
		Debug.Log ("Skater spawned");
		GameObject enemySpawned = Instantiate (skaterPrefab, skaterSpawnPosition, Quaternion.identity, gameObject.transform) as GameObject;
		enemySpawned.GetComponent<SkaterBehavior> ().startUpwards = skaterStartUpwards;
	}

	/* not used in this version
	//spawns a "Boomerang" type enemy based on a true/false value
	public void SpawnBoomerang (bool boomerangSwingDownwards) {
		//sets spawnpoint based on "boomerangSwingDownwards"'s value
		if (boomerangSwingDownwards == true) {
			boomerangSpawnPosition = new Vector3 (xmin, ymax);
		} else {
			boomerangSpawnPosition = new Vector3 (xmin, ymin);
		}

		//spawns the enemy at the determined point
		Debug.Log ("Boomerang spawned");
		Instantiate (boomerangPrefab, boomerangSpawnPosition, Quaternion.identity, gameObject.transform);
	} */

	//spawns a "Rush" type enemy at a given point
	public void SpawnRush (Vector3 rushSpawnPosition) {
		Debug.Log ("Rush spawned");
		Instantiate (rushPrefab, rushSpawnPosition, Quaternion.identity, gameObject.transform);
	}

	//spawns a "Stalker" type enemy based on a true/false value
	public void SpawnStalker (bool stalkerSpawnTop) {
		if (stalkerSpawnTop == true) {
			stalkerSpawnPosition = new Vector3 (xmax, ymax);
		} else {
			stalkerSpawnPosition = new Vector3 (xmax, ymin);
		}

		//spawns the enemy at the determined position 
		Debug.Log ("Stalker spawned");
		Instantiate (stalkerPrefab, stalkerSpawnPosition, Quaternion.identity, gameObject.transform);
	}

	/* not used in this version
	//spawns Rafflesia 
	public void SpawnRafflesia () {
		rafflesiaSpawnPosition.x = xmax + 5;
		rafflesiaSpawnPosition.y = 0;
		Debug.Log ("Rafflesia spawned");
		Instantiate (rafflesiaPrefab, rafflesiaSpawnPosition, Quaternion.identity, gameObject.transform);
	}
	*/
}
