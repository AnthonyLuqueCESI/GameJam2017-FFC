using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);

	// 2 - Stockage du mouvement
	public Vector2 movement;

	public static int x = 1;
	public static int y = 0;

	float timeLeft = 0.8f;
	float timeLeft2 = 1f;

	private WeaponScript[] weapons;

	void Awake()
	{
		// Récupération de toutes les armes de l'ennemi
		weapons = GetComponentsInChildren<WeaponScript>();
	}

	void Update()
	{
		// 3 - Récupérer les informations du clavier/manette
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		bool shoot = Input.GetKey(KeyCode.Space);

		// 4 - Calcul du mouvement
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		if (GetComponent<Rigidbody2D> ().velocity.x == 0 && GetComponent<Rigidbody2D> ().velocity.y < 0) {
			GetComponent<Rigidbody2D> ().rotation = 270;
			x = 0;
			y = -1;
			makeStepSound ();
		}else if (GetComponent<Rigidbody2D> ().velocity.x == 0 && GetComponent<Rigidbody2D> ().velocity.y > 0) {
			GetComponent<Rigidbody2D> ().rotation = 90;
			x = 0;
			y = 1;
			makeStepSound ();
		}else if (GetComponent<Rigidbody2D> ().velocity.x < 0 && GetComponent<Rigidbody2D> ().velocity.y == 0) {
			GetComponent<Rigidbody2D> ().rotation = 180;
			x = -1;
			y = 0;
			makeStepSound ();
		}else if (GetComponent<Rigidbody2D> ().velocity.x > 0 && GetComponent<Rigidbody2D> ().velocity.y == 0) {
			GetComponent<Rigidbody2D> ().rotation = 0;
			makeStepSound ();
			x = 1;
			y = 0;
		}else if (GetComponent<Rigidbody2D> ().velocity.x < 0 && GetComponent<Rigidbody2D> ().velocity.y < 0) {
			GetComponent<Rigidbody2D> ().rotation = 225;
			x = -1;
			y = -1;
			makeStepSound ();
		}else if (GetComponent<Rigidbody2D> ().velocity.x < 0 && GetComponent<Rigidbody2D> ().velocity.y > 0) {
			GetComponent<Rigidbody2D> ().rotation = 135;
			x = -1;
			y = 1;
			makeStepSound ();
		}else if (GetComponent<Rigidbody2D> ().velocity.x > 0 && GetComponent<Rigidbody2D> ().velocity.y < 0) {
			GetComponent<Rigidbody2D> ().rotation = 315;
			x = 1;
			y = -1;
			makeStepSound ();
		}else if (GetComponent<Rigidbody2D> ().velocity.x > 0 && GetComponent<Rigidbody2D> ().velocity.y > 0) {
			GetComponent<Rigidbody2D> ().rotation = 45;
			x = 1;
			y = 1;
			makeStepSound ();
		}
		if(timeLeft <= 0){
			
		}else{
			timeLeft -= Time.deltaTime;
		}

		if(timeLeft2 <= 0){

		}else{
			timeLeft2 -= Time.deltaTime;
		}

		if (shoot && timeLeft2<=0)
		{
			foreach (WeaponScript weapon in weapons)
			{
				// On fait tirer toutes les armes automatiquement
				if (weapon != null && weapon.CanAttack)
				{
					weapon.Attack(true);
					SoundEffect.Instance.MakeGunShot ();
				}
			}
		}
	}

	void FixedUpdate()
	{
		// 5 - Déplacement
		//rigidbody2D.velocity = movement;
		GetComponent<Rigidbody2D>().velocity = movement;
	}

	private void makeStepSound(){
		if (timeLeft <= 0) {
			timeLeft = 0.8f;
			SoundEffect.Instance.MakeStepGrassSound ();	
		}
	}
}
