using UnityEngine;
using System.Collections;
using System;

//using System.Data;
using Npgsql;

public class ScoreManager : MonoBehaviour {

	/* the ScoreManger contains methods to submit/retrieve data from a Postgres database. 
	 * this includes the abilty to update the Score Scenw UI and accept user input */

	// string to connection attributes
	string connectionString = "Server=localhost;" + "Database=pacman;" + "User Id=connoraspinall;"; 

	// containers for UI elements
	public UnityEngine.UI.InputField NameField;
	public UnityEngine.UI.Text TextOut;
	// used in update set to true to stop multiple execution
	bool trigger = false;
	// boolean set to true id user has submitted results
	bool hasBeenSubmitted =false;
	public String Name;
	public int Score = 0;
	// string to hold reader output
	string outputDB = "";
	int LoopCounter = 0;
	// Use this for initialization
	void Start () {
		Score = PlayerPrefs.GetInt("Player Score", Score); // get player score from player prefrences
		PlayerPrefs.SetInt("Player Score", 0); // reset the score
	}

	public void submitData(){
		if (!hasBeenSubmitted && Score != 0) {// only submit if score is more than 0 and score has not already been submited in current instance

			NpgsqlConnection dbcon; // set up a new SQL connection
			
			dbcon = new NpgsqlConnection(connectionString);
			try{
				dbcon.Open();// open the connection to connectionString
			NpgsqlCommand dbcmd = new NpgsqlCommand ("insert into scores(name, score) values ('" + Name + "'," + Score +");", dbcon);
			dbcmd.ExecuteNonQuery();

			// clear and close connection
			dbcmd.Dispose();
			dbcmd = null; // displose of SQL
			dbcon.Close();// close connection
			dbcon = null; // dispose of connection
			GetData();// update UI
			Score = 0;// resut local Score variable

			hasBeenSubmitted = true;
			}catch(Exception e){
				outputDB = e.ToString(); // output error to UI
			}
		}

	}

	void GetData(){
		outputDB = ""; // clear previous output

		NpgsqlConnection dbcon; // set up a new SQL connection
		
		dbcon = new NpgsqlConnection(connectionString);
		try{
			dbcon.Open(); // open the connection to connectionString
		
		NpgsqlCommand dbcmd = new NpgsqlCommand ("SELECT * FROM scores order by score desc limit 10;", dbcon);
		NpgsqlDataReader reader = dbcmd.ExecuteReader();

		while(reader.Read()) { //iterate through reader object
			
			for (int i = 0; i < reader.FieldCount; i++)
			{


				if(i % 3 != 0){
				//skip every thrid index to cut out ID
				outputDB += (reader[i]);// add the contents of the reader to the output string
				// after each full record ad a new line
				if(LoopCounter == 1){
					outputDB += "\n"; 
					
					LoopCounter = 0;
				}else{
					outputDB += " "; // add a space between enititys
					LoopCounter++;
				}

				}
			}
		}
		// clear and close connection
		reader.Close(); // close reader
		reader = null;// dispose of reader
		dbcmd.Dispose();// displose of SQL
		dbcmd = null;// clear SQL
		dbcon.Close(); // close connection
		dbcon = null;// dispose of connection

		}catch(Exception e){
			outputDB = e.ToString();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (trigger == false) {
			
			GetData(); // intial population
			trigger = true;
		}
		Name = NameField.text; // live update Name
		TextOut.text = outputDB; // update text on UI
	}




}
