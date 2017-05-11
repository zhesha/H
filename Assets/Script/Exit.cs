using UnityEngine;
using System.Collections;

public class Exit : Obstacle {
	protected override void checkDone () {
		if (!isDone && transform.position.x - player.transform.position.x < -1f) {
			isDone = true;
			gameControlle.doneExit ();
		}
	}
}
