using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	// Colors 
	// Grey 	- #535353
	// Red		- #F92323
	// Yellow	- #F8FF00
	// LtBlue	- #399FFF
	// Magenta	- #FF00E3
	// Green 	- #05FF00 


	private Color m_colorGrey = new Color32(0x53, 0x53, 0x53, 1);
	private Color m_colorRed = new Color32(0xF9, 0x23, 0x23, 1);	
	private Color m_colorYellow = new Color32(0xF8, 0xFF, 0x00, 1);
	private Color m_colorLightBlue = new Color32(0x39, 0x9F, 0xFF, 1);
	private Color m_colorMagenta = new Color32(0xF9, 0x23, 0x23, 1);
	private Color m_colorGreen = new Color32(0x05, 0xFF, 0x00, 1);

	


	public GameObject m_brickPrefab; 
	public Transform m_brickContainer; 
	// grid of bricks (the playfield) is 13 bricks wide and 27 bricks tall 
	private const int m_fieldHeight = 26; // Rows
	private const int m_fieldWidth = 13; // Columns
	
	private string[,] m_playField; 



	// Use this for initialization
	void Start () {
		m_playField = new string[m_fieldHeight, m_fieldWidth];
		LoadLevel();
		CreateLevel();
	}


	private void LoadLevel() {

		// Level 1 - TODO: Make this better
		string block = " ";
		for(int r = 0; r < m_fieldHeight; r++) {
			for(int c = 0; c < m_fieldWidth; c++) {
				
				switch(r) {
					case 4: 	
						block = "E"; // Grey 
						break; 
					case 5: 
						block = "R"; // Red
						break; 
					case 6: 
						block = "Y"; // Yellow
						break;
					case 7: 
						block = "B"; // Blue
						break; 
					case 8:
						block = "M"; // Magenta
						break; 
					case 9: 
						block = "G"; // Green
						break;
					default: 
						block=  " "; // None
						break;
				}
				
				m_playField[r, c] = block; 
			}
		}
	}

	void CreateLevel(){

		GameObject tmpObj; 
		Vector3 tmpPos; // position of brick to be created (1.0 from last on X and 0.5 from last on Z)
		tmpPos = Vector3.zero;
		float startX = 1.0f; 
		float startZ = 15.0f; 

		for(float r = 0, z = startZ; r < m_fieldHeight; r++, z -= 0.5f) {
			for(int c = 0; c < m_fieldWidth; c++) {
				if (m_playField[(int)r, c] != " ") {
					tmpPos.x = c+1; 
					tmpPos.z = z; 
					tmpObj = Instantiate(m_brickPrefab, tmpPos, Quaternion.identity);
					tmpObj.name = "Brick";
					tmpObj.transform.parent = m_brickContainer;
					SetBrickType(tmpObj, (int)r, c);
				
				}
			}
		}	
	}
	
	
	private void SetBrickType(GameObject tmpObj, int r, int c) {

		
		//TODO: Add a call to the bricks script to set it's type and possibly move this into the brick
		switch(m_playField[r, c]) {
			case "E": // Grey 
				tmpObj.GetComponent<MeshRenderer>().material.color = m_colorGrey;
				break; 
			case "R": // Red
				tmpObj.GetComponent<MeshRenderer>().material.color = m_colorRed;
				break; 
			case "Y": // Yellow
				tmpObj.GetComponent<MeshRenderer>().material.color = m_colorYellow;
				break; 
			case "B": // Blue
				tmpObj.GetComponent<MeshRenderer>().material.color = m_colorLightBlue;
				break; 
			case "M": // Magenta
				tmpObj.GetComponent<MeshRenderer>().material.color = m_colorMagenta;
				break; 
			case "G": // Green
				tmpObj.GetComponent<MeshRenderer>().material.color = m_colorGreen;
				break; 
		}

	}





	// Update is called once per frame
	void Update () {
		// dBugging code
		if(Input.GetKey(KeyCode.O)) {
			dBugLevel();
		}
	}


	public void dBugLevel() {
		string outS = "";

		for(int r = 0; r < m_fieldHeight; r++) {
			for(int c = 0; c < m_fieldWidth; c++ ) {
				outS += "[" + m_playField[r, c] + "]"; 
			}
			outS += "\n";
		}
		Debug.Log(outS);
	}

}


