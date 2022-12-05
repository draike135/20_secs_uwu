using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public List<bool> done = new List<bool>();


    public bool gameDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done.Count == 4)
        {
                gameDone = true;
        }
    }
}
