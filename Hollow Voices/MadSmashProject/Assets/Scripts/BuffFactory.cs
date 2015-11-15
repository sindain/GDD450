
using UnityEngine;
using System;

public class BuffFactory{
	//public variables
	
	//private variables
	
	//public functions

	//private functions

	//static functions
	public static Buff createMoveSpeed(){
		Buff result = new Buff ();
		return result;
	}

	//private classes
	private class MoveSpeedBuff:Buff{
		public MoveSpeedBuff(){
			
		}

		//Handles checking if the buff is expired.
		public virtual void Update(){
		}
		
		public virtual void applyBuff(GameObject pTarget){
			//Apply changes to target
			
		}
		
		//private functions
		public virtual void destroyBuff(){
			//Revert changes that buff made.
			//Destroy this object
		}
	}
}