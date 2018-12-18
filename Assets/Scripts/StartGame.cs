using UnityEngine;

[ExecuteInEditMode]
public class StartGame : MonoBehaviour {

	public CustomUI startButton;
	public BoxController boxController;
	public WordGenerator wordGenerator;
	
	void OnGUI() {
		ShowStart();
	}
	
	void ShowStart() {
		float x = Screen.width * Mathf.Clamp( startButton.rect.x, 0f, 1f );
		float y = Screen.width * Mathf.Clamp( startButton.rect.y, 0f, 1f );
		float width = Screen.width * Mathf.Clamp( startButton.rect.width, 0f, 1f );
		float height = Screen.width * Mathf.Clamp( startButton.rect.height, 0f, 1f );
		Rect rect = new Rect( x, y, width, height );
		startButton.style.fontSize = (int)(Screen.height * startButton.fontSizePercent);		
		if ( GUI.Button( rect, startButton.text, startButton.style ) ) {
            DoStartGame();
		}
	}
	
	void DoStartGame() {
		gameObject.SetActive( false );
		boxController.enabled = true;
		wordGenerator.enabled = true;
	}
}
