/* ************************************************************
 GameManager for Project Name
 States for the FSM System
 Each state has it's own (singleton) class
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */
using UnityEngine;
using Liftlock.FSM;

/* *******************************************************************************************
	NOTE: if you add a game 'state' you need to generate the States/Game+StateName.cs class
******************************************************************************************** */
public enum State { LOADING, MENU, SETTINGS, PLAY, PAUSE, OVER, CREDITS, COUNT }; 

/// <summary>
/// GameManager 
/// The Main GM for the game.
/// </summary>
public class GameManager : MonoBehaviour {

	private FiniteStateMachine<GameManager> m_FSM;
	public State m_state = State.LOADING;
	
	public int m_score = 0;
	public int m_lives = 3;
	public int m_level = 0; 

	public void Awake() {
		Debug.Log("Game Starts...");
		m_FSM = new FiniteStateMachine<GameManager>(); 
		m_FSM.Configure(this, GameLoading.Instance); // initial statup state (loading)
	}

	public void ChangeState(FSMState<GameManager> newState) {
		m_FSM.ChangeState(newState);
	}

	public void Update() {
		//TODO: Add stuff here that needs to always run in the game loop regardless of state
		m_FSM.Update();
	}

	public void ChangeGameState(State newState) {
		m_state = newState;
	}

	public void RevertToPreviousState() {
		m_FSM.RevertToPreviousState();
	}

}