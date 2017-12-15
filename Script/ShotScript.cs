using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

	/// <summary>
	/// Points de dégâts infligés
	/// </summary>
	public int damage = 1;

	/// <summary>
	/// Projectile ami ou ennemi ?
	/// </summary>
	public bool isEnemyShot = false;

	void Start()
	{
		// 2 - Destruction programmée
		Destroy(gameObject, 20); // 20sec
	}
}
