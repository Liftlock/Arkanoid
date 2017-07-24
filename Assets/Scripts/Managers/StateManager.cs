using UnityEngine;
/* ************************************************************
 StateManager for PopPop 
 Enables and Disables actual GameObjects as needed. 
 Depends on GameManager, FMState and FiniteStateManager
 Observes GameManager.m_state for changes
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */
/* 
	SceneName (i.e. Main) 
		|- Camera
	    |- Managers - (Has GameManager Script Attached to it)
		|- EventSystem		
		|- GameStates - (Has THIS Script attached to it)
			|- GameLoading 
			|- GameMenu 
			|- GameSettings 
			|- GamePlay
			|- GamePause
			|- GameOver 
			|- GameCredits 

			Each of the above states is named with "Game" + StateName (see GameManager)
 */
public class StateManager : MonoBehaviour {

	public GameManager m_GM; 
	public GameObject[] m_gameStates; 

	private int m_numGameStates; 
	private State m_state;  

	void Start () {
		m_GM = GameObject.Find("Managers").GetComponent<GameManager>();
		m_state = m_GM.m_state; 

		m_numGameStates = transform.childCount;
		m_gameStates = new GameObject[m_numGameStates];
		
		if (m_numGameStates != (int)State.COUNT) {
			Debug.LogError("The number of listed states in GameManager State enum, does not match the number of actual state game objects in the Heirarchy");
		} else {
		
			for(int i = 0; i < m_numGameStates; i++) {
				State stateName = (State)i; 				
				string lookingFor = "Game" + FixCaseOfState(stateName.ToString());
				m_gameStates[i] = (GameObject)GameObject.Find(lookingFor); 
				if((State)i != State.LOADING) {
					m_gameStates[i].SetActive(false); // Disable all the states except for loading
				}
				
			}
		}

	}
	
	
	void Update () {

		
		if(m_state != m_GM.m_state) {
			// state changed .. clean up m_state and ready the new state
			int oldIndex = -1;
			int newIndex = -1; 
			string oldState = "Game" + FixCaseOfState(m_state.ToString()); 
			string newState =  "Game" + FixCaseOfState(m_GM.m_state.ToString()); 

			for(int i = 0; i < m_numGameStates; i++) {
				

				if(m_gameStates[i].name.ToString() == oldState) { oldIndex = i; }
				if(m_gameStates[i].name.ToString() == newState) { newIndex = i; }	
			}

			if ((oldState == "GamePlay" ) && (newState == "GamePause")) {
				m_gameStates[newIndex].SetActive(true);	
			} else if((oldState == "GamePaused") && (newState == "GamePlay")) { 
				m_gameStates[oldIndex].SetActive(false);	
			} else {
				m_gameStates[oldIndex].SetActive(false);
				m_gameStates[newIndex].SetActive(true);
			}
			m_state = m_GM.m_state;
		}
	}


	// Helpers
	
	/// <summary>
	/// Convert the State name to a PascalCase string 
	/// </summary>
	private string FixCaseOfState(string theState) {
		string retVal = ""; 

		if (theState == null) { 
			retVal = theState;
		} else if (theState.Length < 2) {
			retVal = theState.ToUpper();
		} else {
			theState = theState.ToLower();
			retVal = theState.Substring(0, 1).ToUpper() + theState.Substring(1);
		}
		return retVal;
	}

}
