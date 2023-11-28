using System;
using System.Linq;
using UnityEngine;

public class CheakIfWon : MonoBehaviour
{
    [SerializeField]
    public Transform[] _puzzles;
    private Transform[] _tempTransform;
    private bool _isCompleted = false;

    public bool IsCompleted
    {
        get
        {
            return _isCompleted;
        }
        private set
        {
            _isCompleted = value;
        }
    }
    void Start()
    {
        for(int i=0;i<_puzzles.Length;i++)
        {
            _tempTransform[i] = _puzzles[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        _isCompleted = _puzzles.SequenceEqual(_tempTransform);
        if( _isCompleted )
        {
            FindObjectOfType<GameEventSystem>().TriggerGameWonEvent();
        }
      
    }
}
