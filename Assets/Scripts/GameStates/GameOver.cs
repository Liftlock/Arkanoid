/* ************************************************************
 GameOver for Project Name
 The OVER GameState 
 Depends on GameManager, FMState and FiniteStateManager
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */
using UnityEngine;
using Liftlock.FSM;

/// <summary>
/// GameOver GameState 
/// This class implements a 'thread safe' singleton pattern
/// </summary>
public sealed class GameOver : FSMState<GameManager> {

	// private bool m_stackableState = false; // coming in 1.3.0
	static readonly GameOver m_instance = new GameOver();
	public static GameOver Instance {
		get { return m_instance; }
	}
	static GameOver() {}
	private GameOver() {}

	public override void Enter(GameManager gm) {
		if(gm.m_state != State.OVER) {
			Debug.Log("Entering State 'GAME OVER'");
			gm.ChangeGameState(State.OVER);
		}
	}

	public override void Execute(GameManager gm) {
		//TODO: Manage main execution steps for this gamestate (replace the following)
		if(Input.GetKeyDown(KeyCode.R)) {
			gm.ChangeState(GamePlay.Instance); 
		}
		if(Input.GetKeyDown(KeyCode.M)) {
			gm.ChangeState(GameMenu.Instance); 
		}
		

	}

	public override void Exit(GameManager gm) {
		Debug.Log("Leaving State 'GAME OVER'");
	}

	// public override bool IsStackable() {
	// 	return m_stackableState;
	// }

}
