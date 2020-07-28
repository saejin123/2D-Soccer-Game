using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class difficulty {
	static float secondsToMaxDifficulty = 60;
	public static float GetDifficultyPercent(){
		// return 1; // <- this is to check what the max difficulty is like
		return Mathf.Clamp01(Time.timeSinceLevelLoad/secondsToMaxDifficulty);
	}
}
