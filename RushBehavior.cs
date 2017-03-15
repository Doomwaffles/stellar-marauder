using UnityEngine;
using System.Collections;

//Rush is a type of enemy
public class RushBehavior : MonoBehaviour {

	public float health;
	public float speed;
	public int scoreValue;
	public GameObject splat;
	public AudioClip death;

	private Vector3 playerPosition;
	private PlayerController player;
	private ScoreKeeper scoreKeeper;

	//gives the enemy access to the score
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
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
		Instantiate (splat, transform.position, Quaternion.identity);
		AudioSource.PlayClipAtPoint (death, transform.position);
		Destroy (gameObject);
		scoreKeeper.Score (scoreValue);
		Debug.Log (scoreValue + " points earned");
	}

	//moves the enemy based on the player position
	void Update () {
		playerPosition = new Vector3 (player.transform.position.x, player.transform.position.y);
		transform.position += Vector3.left * speed * Time.deltaTime;
		if (playerPosition.y > transform.position.y) {
			transform.position += Vector3.up * speed / 2 * Time.deltaTime;
		} else if (playerPosition.y < transform.position.y) {
			transform.position += Vector3.down * speed / 2 * Time.deltaTime;
		}
	}
}