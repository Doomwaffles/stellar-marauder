using UnityEngine;
using System.Collections;

//Boomerang is a type of enemy, not a projectile
public class BoomerangBehavior : MonoBehaviour {

	//this isn't actually finished; it was cut for time but may be added back in later
	Vector3 startPos;

	public float health;
	public float projectileSpeed;
	public float shotsPerSecond;
	public float speed;
	public GameObject projectilePrefab;
	public GameObject explosion;
	public AudioClip fire;
	public AudioClip death;
	public EnemySpawner enemySpawner;

	private bool swingDown;
	private bool movingDown;

	void Start () {
		enemySpawner = GameObject.Find ("EnemySpawner").GetComponent<EnemySpawner> ();
		startPos = new Vector3 (transform.position.x, transform.position.y);

		//sets the enemy's path
		if (startPos.y > 0) {
			swingDown = true;
		} else if (startPos.y < 0) {
			swingDown = false;
		}

		MoveIn ();
	}

	//moves the enemy initially
	void MoveIn () {
		if (swingDown == true) {
			//transform.position
		}
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

	//plays a death sound and animation, destroys the enemy
	void Death () {
		Instantiate (explosion, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint (death, transform.position);
		Destroy (gameObject);
	}

	//creates a projectile at its position and plays a sound
	void Fire () {
		AudioSource.PlayClipAtPoint (fire, transform.position);

		GameObject projectile = Instantiate (projectilePrefab, transform.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-projectileSpeed, 0, 0);
	}

	//randomly shoots based on a set time, and becomes more likely as time passes
	void Update () {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}

		if (transform.position.y >= enemySpawner.ymin) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	}
}
