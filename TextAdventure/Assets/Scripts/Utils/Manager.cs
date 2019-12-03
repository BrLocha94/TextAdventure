using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    //SoundController soundController;
    //SceneController sceneController;
    //GameDatabase gameDatabase;

	void Start ()
    {
        SoundController.instance();
        SceneController.instance();
        GameDatabase.instance();
	}
}
