using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject nextButton;
    [SerializeField] List<GameObject> tutorialWindows;

    int currentStep = 0;

    public void NextStep()
    {
        if(previousButton.activeInHierarchy == false)
            previousButton.SetActive(true);

        if (currentStep == tutorialWindows.Count - 1)
        {
            nextButton.SetActive(false);
        }
        else
        {
            currentStep += 1;
        }

        tutorialWindows[currentStep - 1].SetActive(false);
        tutorialWindows[currentStep].SetActive(true);
    }

    public void PreviousStep()
    {
        if (nextButton.activeInHierarchy == false)
            nextButton.SetActive(true);

        if (currentStep == 1)
        {
            previousButton.SetActive(false);
        }

        currentStep -= 1;

        tutorialWindows[currentStep + 1].SetActive(false);
        tutorialWindows[currentStep].SetActive(true);
    }
}
