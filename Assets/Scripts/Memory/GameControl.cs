using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    GameObject token;
    [SerializeField]
    List<GameObject> tokenList = new List<GameObject> {};
    List<int> faceIndexes = new List<int> { 0, 1, 2, 0, 1, 2};
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    public bool win = false;

    [SerializeField]
    int[] visibleFaces = { -1, -2 };

    void Start()
    {
        int originalLength = faceIndexes.Count;
        float xPosition = -3.25f;
        float yPosition = 3.83f;

        for (int i = 0; i < 5; i++)
        {
            shuffleNum = rnd.Next(0, (faceIndexes.Count));
            xPosition = xPosition + 4.5f;
            var temp = GameObject.Instantiate(token, new Vector3(
                xPosition, yPosition, -5),
                Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
            temp.transform.rotation = Quaternion.Euler(270,0,0);

            tokenList.Add(temp);
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            if (i == (originalLength/2 - 2))
            {
                xPosition = -3.07f - 4.5f;
                yPosition = 1f;
            }
        }
        token.GetComponent<MainToken>().faceIndex = faceIndexes[0];
    }

    public bool TwoCardsUp()
    {
        bool cardsUp = false;
        if(visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        if(visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    public bool CheckMatch()
    {
        bool success = false;
        if(visibleFaces[0] == visibleFaces[1])
        {
            for (int t = 0; t < tokenList.Count; t++){
                if (tokenList[t].GetComponent<MainToken>().faceIndex == visibleFaces[0] || tokenList[t].GetComponent<MainToken>().faceIndex == visibleFaces[1]){
                    tokenList[t].GetComponent<MainToken>().Match();
                }
            }
            if(win){
                // do something
            }
        
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        return success;
    }

    private void Win(){
        for(int t = 0; t < tokenList.Count; t++){
            if(!tokenList[t].GetComponent<MainToken>().matched){return;}
        }
        win = true;
    }

    private void Awake()
    {
        token = GameObject.Find("Token");
        tokenList.Add(token);
    }

    void Update()
    {
        Win();
    }

}
