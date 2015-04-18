using UnityEngine;
using System.Collections;
using System.IO;
public class orangeSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		Debug.Log("Orange");
		//StreamWriter writer = new StreamWriter("config");
		int linePointer = 0;
		string currentOption = "hold";
		StreamReader ConfigInput = new StreamReader("config");
		while((currentOption = ConfigInput.ReadLine())!= null){
			if (currentOption == "Colour"){
				linePointer++;
			}
		}
		ConfigInput.Close();
		string[] lines = System.IO.File.ReadAllLines("config");
		lines [linePointer] = "4";
		System.IO.File.WriteAllLines("config",lines);
		//writer.Close();
}
}
