/* ************************************************************
 GameSettings for Project Name
 The SETTINGS GameState 
 Depends on GameManager, FMState and FiniteStateManager
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */
using UnityEngine;
using Liftlock.FSM;

/// <summary>
/// GameSettings GameState 
/// This class implements a 'thread safe' singleton pattern
/// </summary>
public sealed class GameSettings : FSMState<GameManager> {

	// private bool m_stackableState = true; // coming in 1.3.0
	static readonly GameSettings m_instance = new GameSettings();
	public static GameSettings Instance {
		get { return m_instance; }
	}
	static GameSettings() {}
	private GameSettings() {}

	public override void Enter(GameManager gm) {
		if(gm.m_state != State.SETTINGS) {
			Debug.Log("Entering State 'SETTINGS'");
			gm.ChangeGameState(State.SETTINGS);
		}
	}

	public override void Execute(GameManager gm) {
		//TODO: Manage main execution steps for this gamestate (replace the following)
		if(Input.GetKeyDown(KeyCode.Escape)) {
			gm.RevertToPreviousState();
		}

	}

	public override void Exit(GameManager gm) {
		Debug.Log("Leaving State 'SETTINGS'");
	}

	// public override bool IsStackable() {
	// 	return m_stackableState;
	// }

}
