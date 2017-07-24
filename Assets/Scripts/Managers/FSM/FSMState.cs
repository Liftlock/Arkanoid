/* ************************************************************
 FSMState
 The LiftlockStudios abstract FSM class
 Works with the FiniteStateManager Class
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */

namespace Liftlock.FSM {
	abstract public class FSMState<T> {
		abstract public void Enter(T entity);
		abstract public void Execute(T entity);
		abstract public void Exit(T entity);
		// abstract public bool IsStackable();
	}
}
