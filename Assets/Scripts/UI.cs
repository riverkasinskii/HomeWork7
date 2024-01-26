using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Text hpText;
    [SerializeField] Text levelText;
    [SerializeField] Text scoreText;

    public void UpdateScoreAndLevel()
    {
        levelText.text = $"Level {Stats.Level}";
        scoreText.text = "Score " + Stats.Score.ToString("D4");
    }

    public void UpdateHp(int hp)
    {
        hpText.text = $"HP: {hp}";
    }
}
