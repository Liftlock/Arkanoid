/* ************************************************************
 GameCredits for Project Name
 The Credits GameState 
 Depends on GameManager, FMState and FiniteStateManager
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */

using UnityEngine;
using Liftlock.FSM;

/// <summary>
/// GamePause GameState 
/// This class implements a 'thread safe' singleton pattern
/// </summary>
public sealed class GameCredits : FSMState<GameManager> {
	// private bool m_stackableState = false; // coming in 1.3.0
	static readonly GameCredits m_instance = new GameCredits();
	public static GameCredits Instance {
		get {
			return m_instance;
		}
	}
	static GameCredits() {}
	private GameCredits() {}

	public override void Enter(GameManager gm) {
		if(gm.m_state != State.CREDITS) {
			Debug.Log("Entering State 'CREDITS'");
			gm.ChangeGameState(State.CREDITS);
		}
	}

	public override void Execute(GameManager gm) {
		//TODO: Manage main execution steps for this gamestate (replace the following)
		if(Input.GetKeyDown(KeyCode.Escape)) {
			gm.ChangeState(GameMenu.Instance); 
		}
	}

	public override void Exit(GameManager gm) {
		Debug.Log("Leaving State 'CREDITS'");
	}

	// public override bool IsStackable() {
	// 	return m_stackableState;
	// }

}
