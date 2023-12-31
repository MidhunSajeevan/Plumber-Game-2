using UnityEngine;
using UnityEngine.Events;

public class GameEventSystem : MonoBehaviour
{
    public UnityEvent onGameOver;
    public UnityEvent onGameWon;
    public void TriggerGameOverEvent()
    {
        onGameOver.Invoke();
    }
    public void TriggerGameWonEvent()
    {
        onGameWon.Invoke();
    }
}
