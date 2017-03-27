using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PuzzleUtility 
{
	public static bool checkState(Puzzblestate state)
	{
		for(int i=0;i < 9;i++)
		{
			if(state.state[i] != i) return false;
		}
		
		return true;
	}
}
