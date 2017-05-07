using UnityEngine;
using System.Collections;

[System.Serializable]
public class Progress {

    public string bestScore;

	public Progress (string score) {
        bestScore = score;
    }
}
