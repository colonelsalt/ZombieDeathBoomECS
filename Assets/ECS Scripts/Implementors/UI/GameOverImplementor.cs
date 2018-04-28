using UnityEngine;
using UnityEngine.UI;
using Svelto.ECS;

public class GameOverImplementor : MonoBehaviour, IImplementor, IGameOverComponent
{
    private Text m_GameOverTitle;

    public bool isGameOver
    {
        set
        {
            m_GameOverTitle.enabled = value;
        }
    }

    private void Awake()
    {
        m_GameOverTitle = GetComponent<Text>();
    }

}