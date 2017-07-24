/* ************************************************************
 FiniteStateMachine 
 The LiftlockStudios FiniteStateMAching
 This is a C# Implementation of Matt Bucklands FSM 
 Uses the abstract FSMState class
   
 Copyright 2017 Liftlock Studios Inc. - All Rights Reserved
 Version: 1.2.0
 Coded By: Robert French (robert@liftlockstudios.com)
 Last Update: July 4 2017
************************************************************ */
/*
	Version 1.2.0: 
		- Added StateManager Script for buildup/teardown
		- Changed States to State
		- Added Credit State to Default lineup
		- Changed Previous state to a stack for multiple backouts.

	Version 1.1.0: 
		- Removed un-needed global state
		- Renamed local GM instances to gm (from gameManager)

	Version 1.0.0: 
		- Initial release 
 */
using System.Collections.Generic;

namespace Liftlock.FSM {
	public class FiniteStateMachine <T> {
		private T m_owner; 
		private FSMState<T> m_currentState; 
		private bool m_revertingState; 

		private Stack<FSMState<T>> m_previousStates = new Stack<FSMState<T>>();

		public void Awake(){
			m_currentState = null;
			m_revertingState = false;
		}

		public void Configure(T owner, FSMState<T> initialState){
			m_owner = owner;
			m_previousStates.Push(initialState);
			ChangeState(initialState);
		}

		public void Update() {
			if(m_currentState != null) { 
				m_currentState.Execute(m_owner); 
			}
		}

		public void ChangeState(FSMState<T> newState) {
			
			if(newState == m_previousStates.Peek() && m_previousStates.Count > 1) {
				RevertToPreviousState(); // we can just restore the prev state
			} else {
				if(!m_revertingState) {
					m_previousStates.Push(m_currentState);
				}
				
				if(m_currentState != null) { 
					m_currentState.Exit(m_owner); 
				}

				m_currentState = newState; // actual state change
				if(m_currentState != null) { 
					m_currentState.Enter(m_owner); 
				}

				m_revertingState = false;	
			}
		}

		public void RevertToPreviousState() {
			if(m_previousStates.Count > 1) { 
				m_revertingState = true; 
				ChangeState(m_previousStates.Pop());
			}
		}
	}; 
}