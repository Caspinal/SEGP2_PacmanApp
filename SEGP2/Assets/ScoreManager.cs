using UnityEngine;
using System.Collections;
using System;

//using System.Data;
using Npgsql;

public class ScoreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//WggK8eSt
		//NpgsqlConnection conn = new NpgsqlConnection("Server=segp2015-a6.hosting.comp.brad.ac.uk;Port=5432;User Id=jleadbe2;Password=WggK8eSt;Database=jleadbe2_scores;");
		NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;User Id=connoraspinall;Database=connoraspinall;");
		NpgsqlCommand command = new NpgsqlCommand("select version()", conn);
		NpgsqlCommand getscores = new NpgsqlCommand("select name from scores;", conn);
		   
		string output;
		string scores;

		try{
		conn.Open();

				
			try{

				output = (String)command.ExecuteScalar();
				scores = (String)getscores.ExecuteScalar();
				Debug.Log(output);

				NpgsqlDataReader dr = getscores.ExecuteReader();
					
				while(dr.Read()){

						for (int i = 0; i < dr.FieldCount; i++){
						Console.Write("{0} \t", dr[i]);
						}
						Debug.Log("");
					}
					
			}catch(Exception S1){
				Debug.Log("Connection could not be established: " + S1);

			}

		}catch(Exception S1){
			Debug.Log("Connection could not be established: " + S1);
			
		}




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
