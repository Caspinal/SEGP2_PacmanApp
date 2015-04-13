using UnityEngine;
using System.Collections;
using System.Diagnostics;
public class callFromBat : MonoBehaviour {

	// Use this for initialization
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
