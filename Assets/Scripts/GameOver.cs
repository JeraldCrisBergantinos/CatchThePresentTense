using UnityEngine;

[ExecuteInEditMode]
public class GameOver : MonoBehaviour {
	
	public CustomUI titleLabel;
	public CustomUI scoreLabel;
	public CustomUI highScoreLabel;
	public CustomUI tryAgainButton;
	
	public string menuSceneName;
	public SceneFader sceneFader;
	
	public BoxController boxController;
	public WordGenerator wordGenerator;

	void OnGUI() {
		ShowTitle();
		ShowScore();
		ShowHighScore();
		ShowTryAgain();
	}
	
	void ShowTitle() {
		ShowLabel( titleLabel );
	}
	
	void ShowScore() {
		ShowLabel( scoreLabel );
	}
	
	void ShowHighScore() {
		ShowLabel( highScoreLabel );
	}
	
	void ShowLabel( CustomUI customUI ) {
		float x = Screen.width * Mathf.Clamp( customUI.rect.x, 0f, 1f );
		float y = Screen.width * Mathf.Clamp( customUI.rect.y, 0f, 1f );
		float width = Screen.width * Mathf.Clamp( customUI.rect.width, 0f, 1f );
		float height = Screen.width * Mathf.Clamp( customUI.rect.height, 0f, 1f );
		Rect rect = new Rect( x, y, width, height );
		customUI.style.fontSize = (int)(Screen.height * customUI.fontSizePercent);
		GUI.Label( rect, customUI.text, customUI.style );
	}
	
	void ShowTryAgain() {
		float x = Screen.width * Mathf.Clamp( tryAgainButton.rect.x, 0f, 1f );
		float y = Screen.width * Mathf.Clamp( tryAgainButton.rect.y, 0f, 1f );
		float width = Screen.width * Mathf.Clamp( tryAgainButton.rect.width, 0f, 1f );
		float height = Screen.width * Mathf.Clamp( tryAgainButton.rect.height, 0f, 1f );
		Rect rect = new Rect( x, y, width, height );
		tryAgainButton.style.fontSize = (int)(Screen.height * tryAgainButton.fontSizePercent);		
		if ( GUI.Button( rect, tryAgainButton.text, tryAgainButton.style ) ) {
			StopAll();
			Time.timeScale = 1f;
			sceneFader.FadeTo( menuSceneName );
		}
	}
	
	public void SetScore( int score ) {
		scoreLabel.text = score.ToString();
		
		int highScore = PlayerPrefs.GetInt( "HighScore", 0 );
		if ( score > highScore ) {
			highScore = score;
			PlayerPrefs.SetInt( "HighScore", highScore );
		}
		highScoreLabel.text = "High Score: " + highScore.ToString();
	}
	
	void StopAll() {
		GameObject[] words = GameObject.FindGameObjectsWithTag( "Word" );
		foreach (GameObject item in words) {
			WordController wc = item.GetComponent<WordController>();
			if ( wc != null ) {
				wc.enabled = false;
			}
		}
		
		boxController.enabled = false;
		wordGenerator.enabled = false;
	}
}
