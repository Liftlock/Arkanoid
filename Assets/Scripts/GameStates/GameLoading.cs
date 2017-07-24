/* ************************************************************
 GameLoading for Project Name
 The LOADING GameState 
 Depends on GameManager, FMState and FiniteStateManager
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 16 2017
************************************************************ */
using UnityEngine;
using Liftlock.FSM;

/// <summary>
/// GameLoading GameState 
/// This class implements a 'thread safe' singleton pattern
/// </summary>
public sealed class GameLoading : FSMState<GameManager> {

	// private bool m_stackableState = false; // coming in 1.3.0
	private float m_targetTime = 5.0f;
	static readonly GameLoading m_instance = new GameLoading();
	public static GameLoading Instance {
		get {
			return m_instance;
		}
	}
	static GameLoading() {}
	private GameLoading() {}

	public override void Enter(GameManager gm) {
		if(gm.m_state != State.LOADING) {
			Debug.Log("Entering State 'LOADING'");
			gm.ChangeGameState(State.LOADING);
		}
	}

	public override void Execute(GameManager gm) {
		//TODO: Manage main execution steps for this gamestate (replace the following)
		m_targetTime -= Time.deltaTime;
		if (m_targetTime <= 0.0f) {
			gm.ChangeState(GameMenu.Instance);
		}
	}

	public override void Exit(GameManager gm) {
		Debug.Log("Leaving State 'LOADING'");
	}

	// public override bool IsStackable() {
	// 	return m_stackableState;
	// }

}
