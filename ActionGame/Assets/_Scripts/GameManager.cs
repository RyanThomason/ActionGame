using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int wave = 1;
    public int coins = 0;

    public Text waveTxt;
    public Text coinTxt;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        waveTxt.text = wave.ToString();
        coinTxt.text = coins.ToString();

    }
}
