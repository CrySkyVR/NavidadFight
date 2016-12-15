using UnityEngine;
using System.Collections;

public class hand : MonoBehaviour {

	// Use this for initialization

	public float hand_speed = 70f;

	private bool onHostia=false;
	private bool efectoHostia=false;

	public GameObject spawner;
	public GameObject word_spawner;

	public GameObject particulas;



	//public GameObject words_combo;

	public float fireRate = 0.5F;

	private int selectorWord = 0;

	private string[] words;

	private AudioSource otherClip;

	public GameObject fulano;

	private float DURATION_IN_SECONDS = 0.3f; // temporizador;





	void Start () {



		fulano = GameObject.Find ("fulano");

		otherClip = GameObject.Find ("fulano").GetComponent<AudioSource> ();

		words= new string[]{"word_delicious01","word_epic01","word_tasty01","word_combo01"};

		OnCaranchoa ();


	}

	void OnCaranchoa(){
		otherClip.Play ();
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			onHostia = true;
			StartCoroutine(waitAndFade());
			fireRate = Time.time + fireRate;
		

		}

		if (onHostia) {

			selectorWord = Random.Range (0, 4);

			//Debug.Log(words[selectorWord]);
			Debug.Log(selectorWord);
			GetComponent<Animator>().Play("hostia01");
			onHostia = false;


		}// end onHostia

		if (efectoHostia) {
			fulano.GetComponent<Animator> ().Play ("galleta");


			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();

			otherClip.Play ();


			Vector3 spawner_position = spawner.transform.position;
			Vector3 word_spawner_position = word_spawner.transform.position;

			//Debug.Log (spawner_position);
			GameObject particulas_spw = (GameObject)Instantiate (particulas, spawner_position, Quaternion.identity);
			particulas_spw.transform.rotation = Quaternion.Euler (-90,0,0);
			Destroy (particulas_spw, 3f);

			GameObject paf = (GameObject)Instantiate (Resources.Load ("paf"), spawner_position, Quaternion.identity);
			Destroy (paf, 0.5f);

			GameObject words_spw = (GameObject)Instantiate (Resources.Load (words [selectorWord]), word_spawner_position, Quaternion.identity);
			Destroy (words_spw, 3f);
			efectoHostia = false;

		}
	
	}// end update

	// Esta función sirve para generar un retraso en una acción. En este caso los efectos de la hostia.
	private IEnumerator waitAndFade() { 
		yield return new WaitForSeconds(DURATION_IN_SECONDS);
		efectoHostia = true;

	}// End IEnumerator;


}
