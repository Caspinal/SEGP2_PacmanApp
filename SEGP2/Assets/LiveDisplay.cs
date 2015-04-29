using UnityEngine;
using System.Collections;

// This class manages the displaying of the live sprites on the UI
public class LiveDisplay : MonoBehaviour {

	// create holders for UI.Image container
	public UnityEngine.UI.Image live1;
	public UnityEngine.UI.Image live2;
	public UnityEngine.UI.Image live3;
	public DataHolder DH;
	public GameObject MC;
	// Use this for initialization
	void Start () {
		MC = GameObject.Find("Main Camera");
		DH = MC.GetComponent<DataHolder>();
	}
	
	// Update is called once per frame
	void Update () {
	// update UI live sprites in realtime acording to the value of lives in the dataholder
		if (DH.lives == 2) {
			Destroy(live3);
		} else if (DH.lives == 1){
			Destroy(live2);

		} else if(DH.lives == 0){
			Destroy(live1);

		}


	}
}
