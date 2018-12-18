using UnityEngine;

[System.Serializable]
public class CustomUI {

	public Rect rect;
	public string text;
	public GUIStyle style;
	[Range(0f,1f)]
	public float fontSizePercent;
	
}
