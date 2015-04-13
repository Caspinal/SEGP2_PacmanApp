using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class CallFromShell : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		ProcessStartInfo Shell = new ProcessStartInfo(); 
		Shell.FileName = "Generate.sh";
		Shell.UseShellExecute = false; 
		Shell.RedirectStandardOutput = true;

		Process.Start(Shell);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
