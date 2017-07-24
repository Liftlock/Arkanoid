/* ************************************************************
 GamePlay for Project Name
 The PLAY GameState 
 Depends on GameManager, FMState and FiniteStateManager
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */
using UnityEngine;
using Liftlock.FSM;

/// <summary>
/// GamePlay GameState 
/// This class implements a 'thread safe' singleton pattern
/// </summary>
public sealed class GamePlay : FSMState<GameManager> {

	// private bool m_stackableState = false; // coming in 1.3.0
	static readonly GamePlay m_instance = new GamePlay();
	public static GamePlay Instance {
		get {
			return m_instance;
		}
	}
	static GamePlay() {}
	private GamePlay() {}

	public override void Enter(GameManager gm) {
		if(gm.m_state != State.PLAY) {
			Debug.Log("Entering State 'PLAY'");
			gm.ChangeGameState(State.PLAY);
		}
	}

	public override void Execute(GameManager gm) {
		//TODO: Manage main execution steps for this gamestate (replace the following)
		if(Input.GetKeyDown(KeyCode.P)) {
			gm.ChangeState(GamePause.Instance); 
		}

		if(Input.GetKeyDown(KeyCode.Q)) {
			gm.ChangeState(GameOver.Instance); 
		}
	}

	public override void Exit(GameManager gm) {
		Debug.Log("Leaving State 'PLAY'");
	}

	// public override bool IsStackable() {
	// 	return m_stackableState;
	// }

}
