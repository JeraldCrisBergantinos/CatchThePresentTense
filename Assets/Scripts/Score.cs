using UnityEngine;

[ExecuteInEditMode]
public class Score : MonoBehaviour {
	
	public CustomUI labelScore;
	public int scoreValue = 0;

	void OnGUI() {
		ShowScore();
	}
	
	void ShowScore() {
		float x = Screen.width * Mathf.Clamp( labelScore.rect.x, 0f, 1f );
		float y = Screen.width * Mathf.Clamp( labelScore.rect.y, 0f, 1f );
		float width = Screen.width * Mathf.Clamp( labelScore.rect.width, 0f, 1f );
		float height = Screen.width * Mathf.Clamp( labelScore.rect.height, 0f, 1f );
		Rect rect = new Rect( x, y, width, height );
		labelScore.style.fontSize = (int)(Screen.height * labelScore.fontSizePercent);
		GUI.Label( rect, labelScore.text, labelScore.style );
	}
	
	void Update() {
		labelScore.text = "Score : " + scoreValue.ToString();
	}
}
