using UnityEngine;

public class Word : MonoBehaviour {
	
	public float destroyX = -300f;
	public Transform collisionBox;
	public float scalePerCharacter = 6.5f;
	public WordProblem wordProblem;
	public int scoreValue = 10;
	
	private Score score;
	private bool collided = false;
	private GameOver gameOver;
	private AudioManager audioManager;
	
	void Start() {
		GameObject go1 = GameObject.FindGameObjectWithTag( "Score" ) as GameObject;
		score = go1.GetComponent<Score>();
		
		GameObject go2 = GameObject.FindGameObjectWithTag( "GameOver" ) as GameObject;
		gameOver = go2.GetComponent<GameOver>();
		
		GameObject go3 = GameObject.FindGameObjectWithTag( "AudioManager" ) as GameObject;
		audioManager = go3.GetComponent<AudioManager>();
	}
	
	public void SetProblem( WordProblem wp ) {
		wordProblem = wp;
		
		Vector3 scale = collisionBox.localScale;
		scale.x = wordProblem.text.Length * scalePerCharacter;
		collisionBox.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		if ( transform.position.x <= destroyX ) {
			Destroy( gameObject );
		}
	}
	
	void OnTriggerEnter( Collider other ) {
		if ( collided )
			return;
		
		if ( other.CompareTag("Box") ) {
			collided = true;
			
			if ( wordProblem.isPresentTense ) {
				audioManager.PlayHit();
				Destroy( gameObject );
				score.scoreValue += scoreValue;
			}
			else {
				Time.timeScale = 0f;
				audioManager.PlayGameOver();
				gameOver.enabled = true;
				gameOver.SetScore( score.scoreValue );
			}
		}
	}
}
