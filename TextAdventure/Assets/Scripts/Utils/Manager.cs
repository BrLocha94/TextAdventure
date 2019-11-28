using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    SoundController soundController;
    SceneController sceneController;
    GameDatabase gameDatabase;

	void Start ()
    {
        soundController = SoundController.instance();
        sceneController = SceneController.instance();
        gameDatabase = GameDatabase.instance();
	}
}
