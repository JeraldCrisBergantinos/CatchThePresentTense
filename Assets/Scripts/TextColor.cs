using UnityEngine;

public class TextColor : MonoBehaviour {
	
	public TextMesh textMesh;
	
	public void SetColor( string text, string color ) {
		textMesh.text = "<color=" + color + ">" + text + "</color>";
	}
}
