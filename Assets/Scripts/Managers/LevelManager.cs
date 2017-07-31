using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// White   - 50 points	
// Orange  - 60 points
// Cyan    - 70 points
// Green   - 80 points
// Red     - 90 points
// Blue    - 100 points
// Violet  - 110 points
// Yellow  - 120 points

public enum BrickType {	NONE = 0, WHITE = 50, ORANGE = 60, CYAN = 70, GREEN = 80, RED = 90, BLUE = 100, PURPLE = 110, YELLOW = 120, SILVER = 1, GOLD = 1000};

public class LevelManager : MonoBehaviour {

	// Colors 
	// Grey 	- #535353
	// Red		- #F92323
	// Yellow	- #F8FF00
	// LtBlue	- #399FFF
	// Magenta	- #FF00E3
	// Green 	- #05FF00 
	public GameManager m_gameManager;

	private Color m_colorGrey = new Color32(0x53, 0x53, 0x53, 1);
	private Color m_colorRed = new Color32(0xF9, 0x23, 0x23, 1);	
	private Color m_colorYellow = new Color32(0xF8, 0xFF, 0x00, 1);
	private Color m_colorLightBlue = new Color32(0x39, 0x9F, 0xFF, 1);
	private Color m_colorMagenta = new Color32(0xF9, 0x23, 0x23, 1);
	private Color m_colorGreen = new Color32(0x05, 0xFF, 0x00, 1);


	// WIP
	// private float startX = 1.0f; 
	private float startZ = 17.0f; 

	private Vector3 m_brickDimensions = new Vector3(0.95f, 0.45f, 0.45f);


	public GameObject m_brickPrefab; 
	public Transform m_brickContainer;

	// PowerUps 
	public GameObject m_powerUpPrefab; 
	public Texture[] m_powerUpTextures;


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

		GameObject tmpBrick; 
		GameObject tmpPowerUp;
		Vector3 tmpPos; // position of brick to be created (1.0 from last on X and 0.5 from last on Z)
		tmpPos = Vector3.zero;


		for(float r = 0, z = startZ; r < m_fieldHeight; r++, z -= 0.5f) {
			for(int c = 0; c < m_fieldWidth; c++) {
				if (m_playField[(int)r, c] != " ") {
					tmpPos.x = c+1; 
					tmpPos.z = z; 
					tmpBrick = Instantiate(m_brickPrefab, tmpPos, Quaternion.identity);
					tmpBrick.name = "Brick";
					tmpBrick.transform.parent = m_brickContainer;
					GetBrickType(tmpBrick, (int)r, c);

					if(c == 3) {
						// randomly give bricks powerups
						SuperPower tmpPower = SuperPower.LIFE; 
						tmpPowerUp = Instantiate(m_powerUpPrefab, tmpPos, Quaternion.Euler(0, 0, -90));
						tmpPowerUp.GetComponent<PowerUpController>().SetSuperPower(m_powerUpTextures[(int)tmpPower]);
						tmpBrick.GetComponent<BrickController>().AddPowerUp(tmpPowerUp.gameObject);
					}
				
				}
			}
		}	
	}
	
	
	private void SetBrickType(GameObject tmpObj, int r, int c) {

		

	}


	private string GetBrickType(GameObject tmpObj, int r, int c) {

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
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.gray;//  m_colorLightBlue;
				break; 
			case "M": // Magenta
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.magenta;
				break; 
			case "G": // Green
				tmpObj.GetComponent<MeshRenderer>().material.color = m_colorGreen;
				break; 
		}

		return m_playField[r, c]; 
	}





	// Update is called once per frame
	void Update () {
		// dBugging code
		if(Input.GetKey(KeyCode.O)) {
			dBugLevel();
		}


		


	}



	
	void OnDrawGizmos() {
		
		//dBugInit();
		Vector3 tmpPos; // position of brickWire to be created (1.0 from last on X and 0.5 from last on Z)

		if(m_playField != null) {
			
			tmpPos = Vector3.zero; 
			for(float r = 0, z = startZ; r < m_fieldHeight; r++, z -= 0.5f) {
				for(int c = 0; c < m_fieldWidth; c++) {
					if (m_playField[(int)r, c] != " ") {
						tmpPos.x = c+1; 
						tmpPos.z = z; 
						Gizmos.color =  Color.white; // TODO: magic
						if(m_playField[(int)r, c] == "E") { Gizmos.color = Color.gray; }
						if(m_playField[(int)r, c] == "R") { Gizmos.color = Color.red; }
						if(m_playField[(int)r, c] == "Y") { Gizmos.color = Color.yellow; }
						if(m_playField[(int)r, c] == "B") { Gizmos.color = Color.cyan; }
						if(m_playField[(int)r, c] == "M") { Gizmos.color = Color.magenta; }
						if(m_playField[(int)r, c] == "G") { Gizmos.color = Color.green; }

						Gizmos.DrawWireCube(tmpPos, m_brickDimensions); 
					}
				}
			}
		}
	}

	
	private void dBugInit() { // used so we can see the brick placement in edit mode
		m_playField = new string[m_fieldHeight, m_fieldWidth];
		LoadLevel();
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


