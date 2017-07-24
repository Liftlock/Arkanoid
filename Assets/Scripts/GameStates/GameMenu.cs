/* ************************************************************
 GameMenu for Project Name
 The MENU GameState 
 Depends on GameManager, FMState and FiniteStateManager
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */
using UnityEngine;
using Liftlock.FSM;

/// <summary>
/// GameMenu GameState 
/// This class implements a 'thread safe' singleton pattern
/// </summary>
public sealed class GameMenu : FSMState<GameManager> {

	// private bool m_stackableState = false; // coming in 1.3.0
	static readonly GameMenu m_instance = new GameMenu();
	public static GameMenu Instance {
		get {
			return m_instance;
		}
	}
	static GameMenu() {}
	private GameMenu() {}

	public override void Enter(GameManager gm) {
		if(gm.m_state != State.MENU) {
			Debug.Log("Entering State 'MENU'");
			gm.ChangeGameState(State.MENU);
		}
	}

	public override void Execute(GameManager gm) {
		//TODO: Manage main execution steps for this gamestate (replace the following)
		if(Input.GetKeyDown(KeyCode.Space)) {
			gm.ChangeState(GamePlay.Instance); 
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			gm.ChangeState(GameSettings.Instance); 
		}
		
		if(Input.GetKeyDown(KeyCode.C)) {
			gm.ChangeState(GameCredits.Instance); 
		}

		
	}

	public override void Exit(GameManager gm) {
		Debug.Log("Leaving State 'MENU'");
	}


	// public override bool IsStackable() {
	// 	return m_stackableState;
	// }

}
