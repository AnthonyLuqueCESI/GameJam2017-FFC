using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	/// <summary>
	/// Prefab du projectile
	/// </summary>
	public Transform shotPrefab;

	/// <summary>
	/// Temps de rechargement entre deux tirs
	/// </summary>
	public float shootingRate = 0.25f;

	public Rigidbody2D move;

	//--------------------------------
	// 2 - Rechargement
	//--------------------------------

	private float shootCooldown;

	void Start()
	{
		shootCooldown = 0f;
	}

	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	//--------------------------------
	// 3 - Tirer depuis un autre script
	//--------------------------------

	/// <summary>
	/// Création d'un projectile si possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			// Création d'un objet copie du prefab
			var shotTransform = Instantiate(shotPrefab) as Transform;

			// Position
			shotTransform.position = transform.position;

			// Propriétés du script
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			// On saisit la direction pour le mouvement
			//Rigidbody2D move = shotTransform.gameObject.GetComponent<Rigidbody2D>();
			//move = GetComponent<Rigidbody2D>();

			if (move != null)
			{
				//print (move.rotation);
				//move.movement = this.transform.right; // ici la droite sera le devant de notre objet
			}
		}
	}

	/// <summary>
	/// L'arme est chargée ?
	/// </summary>
	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}
}
