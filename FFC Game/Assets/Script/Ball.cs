using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	/// <summary>
	/// Points de dégâts infligés
	/// </summary>
	public int damage = 1;

	/// <summary>
	/// Projectile ami ou ennemi ?
	/// </summary>
	public bool isEnemyShot = false;

	public Vector2 speed = new Vector2(10, 10);

	/// <summary>
	/// Direction
	/// </summary>
	public Vector2 direction;

	private Vector2 movement;

	void Start()
	{
		direction = new Vector2(MovePlayerScript.x, MovePlayerScript.y);
		print (MovePlayerScript.rotate);
		// 2 - Destruction programmée
		Destroy(gameObject, 5); // 5sec
	}

	void awake(){
		GetComponent<Rigidbody2D> ().rotation = MovePlayerScript.rotate;

	}

	void Update()
	{
		// 2 - Calcul du mouvement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate()
	{
		// Application du mouvement
		GetComponent<Rigidbody2D>().velocity = movement;
	}
}
