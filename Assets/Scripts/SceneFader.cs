using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour {
	
	public GUITexture image;
	public float delay = 1f;
	
	public AnimationCurve curve;

	// Use this for initialization
	void Start () {
		image.pixelInset = new Rect( 0, 0, Screen.width, Screen.height );
		
		StartCoroutine( FadeIn() );
	}
	
	public void FadeTo( string scene ) {
		StartCoroutine( FadeOut(scene) );
	}
	
	IEnumerator FadeIn() {
		float t = 1f;
		
		while ( t > 0f ) {
			t -= Time.deltaTime * delay;
			float a = curve.Evaluate(t);
			image.color = new Color( 0f, 0f, 0f, a );
			yield return null;
		}
	}
	
	IEnumerator FadeOut( string scene ) {
		float t = 0f;
		
		while ( t < 1f ) {
			t += Time.deltaTime * delay;
			float a = curve.Evaluate(t);
			image.color = new Color( 0f, 0f, 0f, a );
			yield return null;
		}
		
		Application.LoadLevel( scene );
	}
}
