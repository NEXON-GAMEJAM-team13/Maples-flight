using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class GameManager : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void upScore()
    {
        score += 1;
    }
}
