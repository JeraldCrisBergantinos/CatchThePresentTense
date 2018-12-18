using UnityEngine;

public class BoxController : MonoBehaviour {
	
	public float speed = 180f;
	public float minY = -89f;
	public float maxY = 75f;
	
	private bool actionFlag = false;
	
	// Update is called once per frame
	void Update () {
		
		if ( Input.GetMouseButtonDown(0) ) {
			actionFlag = true;
		}
		else if ( Input.GetMouseButtonUp(0) ) {
			actionFlag = false;
		}
		
		ChangePosition();
	}
	
	void ChangePosition() {
		if ( actionFlag ) {
			if ( transform.position.y < maxY ) {
				transform.position += Vector3.up * speed * Time.deltaTime;
			}
		}
		else {
			if ( transform.position.y > minY ) {
				transform.position += Vector3.down * speed * Time.deltaTime;
			}
		}
	}
}
