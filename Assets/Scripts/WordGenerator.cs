using UnityEngine;

public class WordGenerator : MonoBehaviour {
	
	public float generateSpeed = 1f;
	public GameObject wordPrefab;
	public float startX = 170f;
	public float minY = -88f;
	public float maxY = 80f;
	
	public float[] moveSpeeds;
	public string[] colors;
	public WordProblem[] wordProblems;
	
	private float nextTime = 0;
	
	// Update is called once per frame
	void Update () {
		if ( Time.time > nextTime ) {
			nextTime = Time.time + 1f / generateSpeed;
			GenerateWord();
		}
	}
	
	void GenerateWord() {
		GameObject go = Instantiate( wordPrefab, GenerateStartPosition(), Quaternion.identity ) as GameObject;
		WordController wc = go.GetComponent<WordController>();
		if ( wc != null ) {
			wc.speed = GenerateMoveSpeed();
		}
		
		Word w = go.GetComponent<Word>();
		if ( w != null ) {
			w.SetProblem( GenerateProblem() );
			
			TextColor tc = go.GetComponent<TextColor>();
			if ( tc != null ) {
				tc.SetColor( w.wordProblem.text, GenerateColor() );
			}
		}
	}
	
	Vector3 GenerateStartPosition() {
		float startY = Random.Range( minY, maxY );
		return new Vector3( startX, startY, 0f );
	}
	
	float GenerateMoveSpeed() {
		return moveSpeeds[ Random.Range( 0, moveSpeeds.Length ) ];
	}
	
	string GenerateColor() {
		return colors[ Random.Range( 0, colors.Length ) ];
	}
	
	WordProblem GenerateProblem() {
		return wordProblems[ Random.Range( 0, wordProblems.Length ) ];
	}
}
