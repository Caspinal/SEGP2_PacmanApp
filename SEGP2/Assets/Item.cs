using UnityEngine;
using System.Collections;


// class to destroy gameobject item after 10 seconds

public class Item : MonoBehaviour {
	public bool HasBeenCollected = false;

	public DataHolder DH;
	public GameObject MC;
	float spawnTimer = 10f;
	bool Trigger  = true;


	void Start () {
		 MC = GameObject.Find("Main Camera");
		 DH = MC.GetComponent<DataHolder>();
	}
	
	// UpdaDatate is called once per frame
	void Update () {
		if (Trigger == true){
			DH.SpecialExists = true;
			Trigger = false;
		}
		if (spawnTimer < 1) {
			DH.SpecialExists = false;
			Debug.Log("Goodbye");
			Destroy(gameObject);


				} else {
			spawnTimer -= Time.deltaTime;
			DH.SpecialExists = true;
				}
		transform.Rotate(0, 20 * Time.deltaTime, 0);
	}

}
