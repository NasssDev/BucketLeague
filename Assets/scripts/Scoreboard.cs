using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text teamAScoreText;
    public Text teamBScoreText;

    private int teamAScore;
    private int teamBScore;

    public void AddPointForTeam(Team team)
    {
        if (team == Team.TeamA)
        {
            teamAScore++;
            teamAScoreText.text = teamAScore.ToString();
        }
        else if (team == Team.TeamB)
        {
            teamBScore++;
            teamBScoreText.text = teamBScore.ToString();
        }
    }
}

public enum Team
{
    TeamA,
    TeamB
}

