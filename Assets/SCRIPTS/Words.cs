using UnityEngine;
using System.Collections;

public class Words : MonoBehaviour {

	// Use this for initialization

	public float speed=2f;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.up * speed * Time.deltaTime);
	
	}
}
