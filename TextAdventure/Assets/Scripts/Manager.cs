using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    SoundController soundController;

	void Start ()
    {
        soundController = SoundController.instance();
	}
}
