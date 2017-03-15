using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTimer : MonoBehaviour {

	public float levelTime = 100f;
	public Vector3 enemyPosition;
	public float xmaxPlusOne;
	public float xmaxPlusTwo;

	private string levelName;
	private Text text;
	private EnemySpawner enemySpawner;
	private LevelManager lvlManager;

	//level starts, sets everything up
	void Start () {
		enemySpawner = GameObject.Find ("EnemySpawner").GetComponent<EnemySpawner> ();
		lvlManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();

		//sets the correct timer according to level name
		levelName = (SceneManager.GetActiveScene().name);
		if (levelName == "L1") {
			levelTime = 100f;
			Debug.Log ("Current scene is L1");
			InvokeRepeating ("LevOneTimer", 1f, 1f);
		}
		if (levelName == "L2") {
			levelTime = 88f;
			Debug.Log ("Current scene is L2");
			InvokeRepeating ("LevTwoTimer", 1f, 1f);
		}
		if (levelName == "L3") {
			levelTime = 76f;
			Debug.Log ("Current scene is L3");
			InvokeRepeating ("LevThreeTimer", 1f, 1f);
		}

		//debug script to check times are correct
		text = GetComponent<Text> ();
		text.text = ("Time: " + levelTime);

		//repeatedly invokes a function to use as a timer
		InvokeRepeating ("Timer", 1f, 1f);

	}


	//tracks the time passed, then advances the level when it runs out
	void Timer () {
		if (levelTime > 0) {
			levelTime--;
			text.text = ("Time: " + levelTime);
		}
	}

	//has every event in level one, according to time
	void LevOneTimer () {
		xmaxPlusOne = enemySpawner.xmax + 1f;
		if (levelTime == 96f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 91f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 3f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (enemySpawner.xmax, -3f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 84f) {
			enemySpawner.SpawnSwoop (true);
		} else if (levelTime == 79f) {
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 75f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 4f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 74f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 73f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 72f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 71f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, -4f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 68f) {
			enemySpawner.SpawnSwoop (true);
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 60f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 58f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 4f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (enemySpawner.xmax, -4f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 53f) {
			enemySpawner.SpawnSwoop (true);
		} else if (levelTime == 49f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, -5.5f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 44f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, -3.5f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (xmaxPlusOne, -1.5f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (xmaxPlusOne, 1.5f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (enemySpawner.xmax, 3.5f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 41f) {
			enemySpawner.SpawnSwoop (true);
		} else if (levelTime == 40f) {
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 39f) {
			enemySpawner.SpawnSwoop (true);
		} else if (levelTime == 38f) {
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 32f) {
			enemyPosition = new Vector3 (xmaxPlusOne, 4f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (enemySpawner.xmax, 2.5f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (xmaxPlusOne, -4f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2.5f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 27f) {
			enemySpawner.SpawnSwoop (true);
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 26f) {
			enemySpawner.SpawnSwoop (true);
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 25f) {
			enemySpawner.SpawnSwoop (true);
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 24f) {
			enemySpawner.SpawnSwoop (true);
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 18f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 16f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 14f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 12f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 10f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnArrow (enemyPosition);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnArrow (enemyPosition);
		} else if (levelTime == 8f) {
			enemySpawner.SpawnSwoop (true);
			enemySpawner.SpawnSwoop (false);
		} else if (levelTime == 3f) {
			//***do something to transition
		} else if (levelTime < 1f) {
			lvlManager.LoadNextLevel ();
		}
	}

	//has every event in level two, according to time
	void LevTwoTimer () {
		xmaxPlusOne = enemySpawner.xmax + 1f;
		xmaxPlusTwo = enemySpawner.xmax + 2f;
		if (levelTime == 85f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime == 80f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 75f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 70f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 68f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 1f);
			enemySpawner.SpawnSkater (enemyPosition, true);
			enemyPosition = new Vector3 (enemySpawner.xmax, -1f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 64f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 62f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime == 61f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 58f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 54f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnSkater (enemyPosition, false);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime == 52f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 1f);
			enemySpawner.SpawnSkater (enemyPosition, true);
			enemyPosition = new Vector3 (enemySpawner.xmax, -1f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 50f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 48f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 1f);
			enemySpawner.SpawnSkater (enemyPosition, false);
			enemyPosition = new Vector3 (enemySpawner.xmax, -1f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime == 46f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnSkater (enemyPosition, true);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 44f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 42f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnSkater (enemyPosition, false);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 40f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 38f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnSkater (enemyPosition, false);
			enemyPosition = new Vector3 (xmaxPlusTwo, 1f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 37f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 36f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 34f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnSkater (enemyPosition, true);
			enemyPosition = new Vector3 (xmaxPlusTwo, -1f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime == 33f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime == 30f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 26f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 22f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 20f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnSkater (enemyPosition, true);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 16f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime == 15f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 14f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime == 13f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 12f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnGeese (enemyPosition);
		} else if (levelTime == 9f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnSkater (enemyPosition, true);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnSkater (enemyPosition, false);
		} else if (levelTime == 7f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnSkater (enemyPosition, false);
			enemyPosition = new Vector3 (enemySpawner.xmax, -2f);
			enemySpawner.SpawnSkater (enemyPosition, true);
		} else if (levelTime < 1f) {
			lvlManager.LoadNextLevel ();
		}
	}

	//has every event in level three, according to time
	void LevThreeTimer () {
		xmaxPlusOne = enemySpawner.xmax + 1f;
		xmaxPlusTwo = enemySpawner.xmax + 2f;
		if (levelTime == 72f) {
			enemySpawner.SpawnStalker (true);
		} else if (levelTime == 67f) {
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 63f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 59f) {
			enemySpawner.SpawnStalker (true);
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 56f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 3f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 53f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, -3f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 50f) {
			enemySpawner.SpawnStalker (true);
		} else if (levelTime == 49f) {
			enemySpawner.SpawnStalker (true);
		} else if (levelTime == 46f) {
			enemySpawner.SpawnStalker (false);
			enemySpawner.SpawnStalker (true);
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 42f) {
			enemySpawner.SpawnStalker (true);
			enemyPosition = new Vector3 (xmaxPlusOne, -2f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 39f) {
			enemySpawner.SpawnStalker (false);
			enemyPosition = new Vector3 (xmaxPlusTwo, 2f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 35f) {
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 33f) {
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 32f) {
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 31f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 29f) {
			enemySpawner.SpawnStalker (true);
		} else if (levelTime == 28f) {
			enemySpawner.SpawnStalker (true);
		} else if (levelTime == 27f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 22f) {
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 20f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnRush (enemyPosition);
			enemySpawner.SpawnStalker (true);
		} else if (levelTime == 18f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnRush (enemyPosition);
			enemySpawner.SpawnStalker (true);
		} else if (levelTime == 17f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnRush (enemyPosition);
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 16f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 0f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 15f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, enemySpawner.ymax);
			enemySpawner.SpawnRush (enemyPosition);
			enemyPosition = new Vector3 (xmaxPlusTwo, enemySpawner.ymin);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 14f) {
			enemyPosition = new Vector3 (5f, enemySpawner.ymax);
			enemySpawner.SpawnRush (enemyPosition);
			enemyPosition = new Vector3 (6f, enemySpawner.ymin);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 13f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 3f);
			enemySpawner.SpawnRush (enemyPosition);
			enemyPosition = new Vector3 (xmaxPlusTwo, -3f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 12f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 11f) {
			enemyPosition = new Vector3 (7f, enemySpawner.ymin);
			enemySpawner.SpawnRush (enemyPosition);
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 9f) {
			enemyPosition = new Vector3 (7f, enemySpawner.ymax);
			enemySpawner.SpawnRush (enemyPosition);
			enemyPosition = new Vector3 (8f, enemySpawner.ymin);
			enemySpawner.SpawnRush (enemyPosition);
			enemySpawner.SpawnStalker (true);
		} else if (levelTime == 8f) {
			enemyPosition = new Vector3 (8f, enemySpawner.ymax);
			enemySpawner.SpawnRush (enemyPosition);
			enemyPosition = new Vector3 (7f, enemySpawner.ymin);
			enemySpawner.SpawnRush (enemyPosition);
			enemySpawner.SpawnStalker (false);
		} else if (levelTime == 7f) {
			enemyPosition = new Vector3 (7f, enemySpawner.ymax);
			enemySpawner.SpawnRush (enemyPosition);
			enemyPosition = new Vector3 (8f, enemySpawner.ymin);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 6f) {
			enemyPosition = new Vector3 (enemySpawner.xmax, 2f);
			enemySpawner.SpawnRush (enemyPosition);
			enemyPosition = new Vector3 (xmaxPlusTwo, -2f);
			enemySpawner.SpawnRush (enemyPosition);
		} else if (levelTime == 5f) {
		} else if (levelTime < 1f) {
			lvlManager.LoadNextLevel ();
		}
	}
}
