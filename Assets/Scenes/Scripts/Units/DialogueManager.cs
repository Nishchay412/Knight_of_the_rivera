using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    public GameObject choice1Button;
    public GameObject choice2Button;

    private int affectionPoints = 0;

    void Start()
    {
        dialogueText.text = "Hey... I wanted to ask you something.";
    }

    public void Choice1()
    {
        dialogueText.text = "You look amazing today ❤️";
        affectionPoints += 1;
        ShowFinal();
    }

    public void Choice2()
    {
        dialogueText.text = "So... uh... nice weather?";
        affectionPoints -= 1;
        ShowFinal();
    }

    void ShowFinal()
    {
        choice1Button.SetActive(false);
        choice2Button.SetActive(false);

        Invoke("FinalDecision", 2f);
    }

    void FinalDecision()
    {
        if (affectionPoints > 0)
        {
            dialogueText.text = "Of course I'll be your Valentine 💖";
        }
        else
        {
            dialogueText.text = "Maybe... try again next year 😅";
        }
    }
}
