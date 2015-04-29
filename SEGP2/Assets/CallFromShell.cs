using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class CallFromShell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		// execute the random map generator via external process UNIX solution
		ProcessStartInfo Shell = new ProcessStartInfo(); 
		Shell.FileName = "Generate.sh";
		Shell.UseShellExecute = false; 
		Shell.RedirectStandardOutput = true;

		Process.Start(Shell);
		//Shell.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
