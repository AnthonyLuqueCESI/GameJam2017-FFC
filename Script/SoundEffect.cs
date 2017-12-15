using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

	public static SoundEffect Instance;

	public AudioClip stepGrassSound;

	public AudioClip gunShot;

	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	public void MakeStepGrassSound()
	{
		MakeSound(stepGrassSound);
	}

	public void MakeGunShot()
	{
		MakeSound(gunShot);
	}

	private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
