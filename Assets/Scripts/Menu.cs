using UnityEngine;

[ExecuteInEditMode]
public class Menu : MonoBehaviour {
	
	public CustomUI titleLabel;
	public CustomUI presentTenseLabel;
	public CustomUI presentTensePointLabel;
	public CustomUI nonPresentTenseLabel;
	public CustomUI nonPresentTensePointLabel;
	public CustomUI playButton;
	public CustomUI quitButton;
	
	public string mainSceneName;
	public SceneFader sceneFader;

	void OnGUI() {
		ShowTitle();
		ShowPresentTense();
		ShowNonPresentTense();
		ShowPlay();
		ShowQuit();
	}
	
	void ShowTitle() {
		ShowLabel( titleLabel );
	}
	
	void ShowPresentTense() {
		ShowLabel( presentTenseLabel );
		ShowLabel( presentTensePointLabel );
	}
	
	void ShowNonPresentTense() {
		ShowLabel( nonPresentTenseLabel );
		ShowLabel( nonPresentTensePointLabel );
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
	
	void ShowPlay() {
		ShowButton( playButton, "ToMainScene" );
	}
	
	void ShowQuit() {
		ShowButton( quitButton, "ToQuit" );
	}
	
	void ShowButton( CustomUI customUI, string function ) {
		float x = Screen.width * Mathf.Clamp( customUI.rect.x, 0f, 1f );
		float y = Screen.width * Mathf.Clamp( customUI.rect.y, 0f, 1f );
		float width = Screen.width * Mathf.Clamp( customUI.rect.width, 0f, 1f );
		float height = Screen.width * Mathf.Clamp( customUI.rect.height, 0f, 1f );
		Rect rect = new Rect( x, y, width, height );
		customUI.style.fontSize = (int)(Screen.height * customUI.fontSizePercent);		
		if ( GUI.Button( rect, customUI.text, customUI.style ) ) {
			Invoke( function, 0f );
		}
	}
	
	void ToMainScene() {
		sceneFader.FadeTo( mainSceneName );
	}
	
	void ToQuit() {
		Application.Quit();
	}
}
