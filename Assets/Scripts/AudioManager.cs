using UnityEngine;

public class AudioManager : MonoBehaviour {
	
	public AudioSource audioSource;
	public AudioClip hitClip;
	public AudioClip gameOverClip;

	public void PlayHit() {
		audioSource.PlayOneShot( hitClip );
	}
	
	public void PlayGameOver() {
		audioSource.PlayOneShot( gameOverClip );
	}
}
