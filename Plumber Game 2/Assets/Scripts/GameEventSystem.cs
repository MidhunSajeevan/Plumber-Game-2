using UnityEngine;
using UnityEngine.Events;

public class GameEventSystem : MonoBehaviour
{
    public UnityEvent onGameOver;

    public void TriggerGameOverEvent()
    {
        onGameOver.Invoke();
    }
}
