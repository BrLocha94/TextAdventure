using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;

public class ButtonHolder : MonoBehaviour
{
    bool is_over = false;
    bool count = false;
    float time = 0;

	void Update ()
    {
        if (is_over == false && count == true)
        {
            time += Time.deltaTime;
            if (time >= 5f)
                OutTransition();
        }
	}

    public void InTransition()
    {
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameObject.GetComponent<Lean.Gui.LeanWindow>().TurnOn();

        is_over = false;
        count = true;
        time = 0f;
    }

    public void OutTransition(float transitionTime)
    {
        StartCoroutine(OutTransitionRoutine(transitionTime));
    }

    IEnumerator OutTransitionRoutine(float transitionTime)
    {
        yield return new WaitForSeconds(transitionTime);

        OutTransition();
    }

    private void OutTransition()
    {
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameObject.GetComponent<Lean.Gui.LeanWindow>().TurnOff();

        is_over = false;
        count = false;
        time = 0f;
    }

    public void NormalTransition()
    {
        is_over = false;
        time = 0f;
    }

    public void DownTransition()
    {
        is_over = true;
        time = 0f;
    }
}
