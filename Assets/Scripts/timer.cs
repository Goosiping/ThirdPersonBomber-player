using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    [SerializeField] public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int current = (int)Time.time;
        //text.text = (current / 60).ToString() + ":" + (current % 60).ToString();
        text.text = string.Format("{0}:{1:00}", current / 60, current % 60);
    }
}
