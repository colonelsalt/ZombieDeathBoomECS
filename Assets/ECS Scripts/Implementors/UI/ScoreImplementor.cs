using UnityEngine;
using UnityEngine.UI;

public class ScoreImplementor : MonoBehaviour, IImplementor, IScoreComponent
{
    [SerializeField]
    private int m_PointsPerKill = 10;

    private Text m_ScoreText;

    private int m_CurrentScore;

    public int currentScore
    {
        get
        {
            return m_CurrentScore;
        }

        set
        {
            m_CurrentScore = value;
            m_ScoreText.text = value.ToString();
        }
    }

    public int pointsPerKill
    {
        get
        {
            return m_PointsPerKill;
        }
    }

    private void Awake()
    {
        m_CurrentScore = 0;
        m_ScoreText = GetComponent<Text>();
        m_ScoreText.text = m_CurrentScore.ToString();
    }

}
