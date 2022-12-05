using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class papizon : MonoBehaviour
{
    public GameObject minigame1;
    public GameObject minigame2;
    public GameObject Timer;
    private int final=0;
    private int final2 = 0;
    public bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator test2()
    {
        yield return new WaitForSeconds(20);
    }

    // Update is called once per frame
    void Update()
    {
        if(minigame1.GetComponent<GameOver>().gameDone)
        {
            final = 1;
        }
        if (minigame2.GetComponent<GameControl>().win)
        {
            final2 = 1;
        }
        if(final==1 && final2 ==1)
        {
            test = true;
            print("hey yo");
            Timer.GetComponent<Timer>().timerIsRunning = false;
            test2();
            SceneManager.LoadScene("Win");


        }


    }
}
