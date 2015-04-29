using UnityEngine;
using System.Collections;
using System.Diagnostics;
public class callFromBat : MonoBehaviour {

	// execute the random map generator via external process Microsoft solution
	void Start () {
		ProcessStartInfo Bat = new ProcessStartInfo();
		Bat.FileName = "Generate.bat";
		Bat.UseShellExecute = false;
		Bat.RedirectStandardOutput = true;

		Process.Start (Bat);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
