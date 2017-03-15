using UnityEngine;
using System.Collections;

//Skater is a type of enemy
public class SkaterBehavior : MonoBehaviour {

	public float health;
	public float projectileSpeed;
	public float shotsPerSecond;
	public float speed;
	public int scoreValue;
	public GameObject projectilePrefab;
	public GameObject explosion;
	public AudioClip fire;
	public AudioClip death;
	public bool startUpwards;

	private Vector3 startPos;
	private float ymax;
	private float ymin;
	private ScoreKeeper scoreKeeper;

	//gives the enemy access to the score
	void Start () {
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();

		//sets limits to the y-value
		startPos = new Vector3 (transform.position.x, transform.position.y);
		ymax = startPos.y + 2.5f;
		ymin = startPos.y - 2.5f;
	}

	//reduces health when the player shoots the enemy
	void OnTriggerEnter2D (Collider2D col) {
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

	//moves the enemy up or down
	void MoveVertical (bool StartUpwards) {
		if (startUpwards == true) {
			if (transform.position.y < ymax) {
				transform.position += Vector3.up * speed * Time.deltaTime;
			} else if (transform.position.y >= ymax) {
				startUpwards = !startUpwards;
			}
		}
		if (startUpwards == false) {
			if (transform.position.y > ymin) {
				transform.position += Vector3.down * speed * Time.deltaTime;
			} else if (transform.position.y <= ymin) {
				startUpwards = !startUpwards;
			}
		}
	}

	//randomly shoots based on a set time, and becomes more likely as time passes
	void Update () {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}
		transform.position += Vector3.left * speed * Time.deltaTime;
		MoveVertical (startUpwards);
	}
}