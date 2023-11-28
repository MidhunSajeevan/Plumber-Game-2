using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDistribution : MonoBehaviour
{
    RawImage[] images;
    CheakIfWon cheakIfWon;
    Timer _timer;
    void Start()
    {
        
        images = GetComponentsInChildren<RawImage>();
        cheakIfWon = FindAnyObjectByType<CheakIfWon>();
        _timer = FindAnyObjectByType<Timer>();
    }

    
    void Update()
    {
        int length  = images.Length;
        if(_timer._timer < 80)
        {
            length -= 2;
        }else if(_timer._timer < 40)
        {
            length -= 4;    
        }
      if(cheakIfWon.IsCompleted)
        {
            for(int i = 0; i < length; i++)
            {
                images[i].color = Color.yellow;
            }
        }
    }
}
