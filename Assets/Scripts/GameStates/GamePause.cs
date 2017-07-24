/* ************************************************************
 GamePause for Project Name
 The PAUSE GameState 
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
public sealed class GamePause : FSMState<GameManager> {
	
	// private bool m_stackableState = true; // coming in 1.3.0
	static readonly GamePause m_instance = new GamePause();
	public static GamePause Instance {
		get { return m_instance; }
	}
	static GamePause() {}
	private GamePause() {}

	public override void Enter(GameManager gm) {
		if(gm.m_state != State.PAUSE) {
			Debug.Log("Entering State 'PAUSE'");
			gm.ChangeGameState(State.PAUSE);
		}
	}

	public override void Execute(GameManager gm) {
		//TODO: Manage main execution steps for this gamestate (replace the following)
		if(Input.GetKeyDown(KeyCode.P)) {
			gm.ChangeState(GamePlay.Instance); 
		}
		
		if(Input.GetKeyDown(KeyCode.Escape)) {
			gm.RevertToPreviousState();
		}
	}

	public override void Exit(GameManager gm) {
		Debug.Log("Leaving State 'PAUSE'");
	}

	// public override bool IsStackable() {
	// 	return m_stackableState;
	// }

}
