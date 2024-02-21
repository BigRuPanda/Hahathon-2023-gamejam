using UnityEngine;
using UnityEngine.UI;

public class ButtonSequenceChecker : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public GameObject hammer;
    public GameObject image;
    public AudioSource buttonSound1;
    public AudioSource buttonSound2;

    private Button[] sequence = new Button[3];
    private int sequenceIndex = 0;


    private void Awake()
    {
        button1.onClick.AddListener(OnButton1Pressed);
        button2.onClick.AddListener(OnButton2Pressed);
        button3.onClick.AddListener(OnButton3Pressed);
        button4.onClick.AddListener(OnButton4Pressed);
        button5.onClick.AddListener(OnButton5Pressed);
        button6.onClick.AddListener(OnButton6Pressed);

        sequence[0] = button1;
        sequence[1] = button6;
        sequence[2] = button3;
    }

    private void OnButton1Pressed()
    {
        CheckButtonInSequence(button1);
        buttonSound1.Play();
    }

    private void OnButton2Pressed()
    {
        CheckButtonInSequence(button2);
        buttonSound1.Play();
    }

    private void OnButton3Pressed()
    {
        CheckButtonInSequence(button3);
        buttonSound1.Play();
    }

    private void OnButton4Pressed()
    {
        CheckButtonInSequence(button4);
        buttonSound1.Play();
    }

    private void OnButton5Pressed()
    {
        CheckButtonInSequence(button5);
        buttonSound1.Play();
    }

    private void OnButton6Pressed()
    {
        CheckButtonInSequence(button6);
        buttonSound1.Play();
    }

    private void CheckButtonInSequence(Button button)
    {
        if (button == sequence[sequenceIndex])
        {
            sequenceIndex++;
            if (sequenceIndex == sequence.Length)
            {
                image.gameObject.SetActive(true);
                hammer.gameObject.SetActive(true);
                buttonSound2.Play();
                sequenceIndex = 0;
            }
        }
        else
        {
            sequenceIndex = 0;
        }
    }
}