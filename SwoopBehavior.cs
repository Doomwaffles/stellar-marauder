using UnityEngine;
using System.Collections;

//Swoop is a type of enemy. This script is used for both "Swoop" and "Stalker"
public class SwoopBehavior : MonoBehaviour {

	Vector3 startPos;
	public float health;
	public float projectileSpeed;
	public float shotsPerSecond;
	public float speed;
	public int scoreValue;
	public GameObject projectilePrefab;
	public GameObject explosion;
	public AudioClip fire;
	public AudioClip death;

	private ScoreKeeper scoreKeeper;

	bool moveDown;

	//gives the enemy access to the score, and sets the start position
	void Start () {
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
		startPos = new Vector3 (transform.position.x, transform.position.y);

		//sets the enemy's path
		if (startPos.y > 0) {
			moveDown = true;
		} else if (startPos.y < 0) {
			moveDown = false;
		}
	}

	//reduces health when the player shoots the enemy
	void OnTriggerEnter2D (Collider2D col) {
		//note: projectile and missile mean the same thing
		Projectile missile = col.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage ();
			missile.Hit ();
			if (health <= 0) {
				Death ();
			}
		}
	}

	//plays a death sound and animation, destroys the enemy, and increases the score
	void Death () {
		Instantiate (explosion, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint (death, transform.position);
		Destroy (gameObject);
		scoreKeeper.Score (scoreValue);
		Debug.Log (scoreValue + " points earned");
	}

	//creates a projectile at its position and plays a sound
	void Fire () {
		AudioSource.PlayClipAtPoint (fire, transform.position);

		GameObject projectile = Instantiate (projectilePrefab, transform.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-projectileSpeed, 0, 0);
	}

	void Update () {
		//randomly shoots based on a set time, and becomes more likely as time passes
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}

		//moves the enemy left, and moves it vertically depending on a variable
		transform.position += Vector3.left * speed * Time.deltaTime;
		if (moveDown == true) {
			transform.position += Vector3.down * speed / 3f * Time.deltaTime;
		} else {
			transform.position += Vector3.up * speed / 3f * Time.deltaTime;
		}
	}
}