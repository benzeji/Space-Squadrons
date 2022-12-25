using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TMP_Text textScore;

    private void Start()
    {
        textScore = GetComponent<TMP_Text>();
        textScore.text = "Start";
    }

    public void IncreaseScore(int amountToIncrease) 
    {
        score += amountToIncrease;
        textScore.text = score.ToString();
    }
}