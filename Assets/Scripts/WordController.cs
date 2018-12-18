using UnityEngine;

public class WordController : MonoBehaviour {
	
	public float speed = 90f;
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * speed * Time.deltaTime;
	}
}
