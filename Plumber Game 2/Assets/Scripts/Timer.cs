using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float _timer = 0f;
    private float _timeduration = 60f * 2f;
    private bool _isFlashing = false;
    private float flashInterval = 0.1f;

    [SerializeField] private TextMeshProUGUI _FirstMinut;
    [SerializeField] private TextMeshProUGUI _SecondMinut;
    [SerializeField] private TextMeshProUGUI _Seperator;
    [SerializeField] private TextMeshProUGUI _FirstSecond;
    [SerializeField] private TextMeshProUGUI _SecondSecond;

   
    void Start()
    {
        ResetTimer();
    }

  
    void Update()
    {
        CallTimerFuction();
    }
    private void CallTimerFuction()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            UpdateDisplay(_timer);

            if (_timer < 6 && !_isFlashing)
            {
                _FirstMinut.color = Color.red;
                _SecondMinut.color = Color.red;
                _Seperator.color = Color.red;
                _FirstSecond.color = Color.red;
                _SecondSecond.color = Color.red;
                _isFlashing = true;
                StartCoroutine(FlashTimer());
            }
        }
        else
        {
            flash();
        }
    }

    private void UpdateDisplay(float time)
    {
        float minuets = Mathf.Floor(time / 60);
        float seconds = Mathf.Floor(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minuets, seconds);
        _FirstMinut.text = currentTime[0].ToString();
        _SecondMinut.text = currentTime[1].ToString();
        _FirstSecond.text = currentTime[2].ToString();
        _SecondSecond.text = currentTime[3].ToString();
    }
    public void ResetTimer()
    {

        _timer = _timeduration;
    }
    void flash()
    {
        if (_timer != 0)
        {
            _timer = 0;
            UpdateDisplay(_timer);
      
            FindObjectOfType<GameEventSystem>().TriggerGameOverEvent();
        }
    }
    private void settextDisplay(bool enabled)
    {
        _FirstMinut.enabled = enabled;
        _SecondMinut.enabled = enabled;
        _SecondSecond.enabled = enabled;
        _FirstSecond.enabled = enabled;
        _Seperator.enabled = enabled;
    }
    IEnumerator FlashTimer()
    {
        while (_isFlashing)
        {
            settextDisplay(false);
            yield return new WaitForSeconds(flashInterval);
            settextDisplay(true);
            yield return new WaitForSeconds(flashInterval);
        }
    }
}
