using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainToken : MonoBehaviour
{
    GameObject gameControl;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    public bool isBack;
    public Mesh[] faces;
    public Material[] facesMaterial;
    public Mesh back;
    public Material backMaterial;
    public int faceIndex;
    public bool matched = false;
    public int win = 0;
    public GameObject gameManager;

    public void OnMouseDown()
    {

        if (matched == false)
        {
            if (isBack)
            {
                if (gameControl.GetComponent<GameControl>().TwoCardsUp() == false)
                {
                    isBack = false;
                    GetComponent<MeshRenderer>().material = facesMaterial[faceIndex];
                    meshFilter.mesh = faces[faceIndex];
                    gameControl.GetComponent<GameControl>().AddVisibleFace(faceIndex);
                    matched = gameControl.GetComponent<GameControl>().CheckMatch();
                }
            }
            else
            {
                isBack = true;
                meshFilter.mesh = back;
                GetComponent<MeshRenderer>().material = backMaterial;
                gameControl.GetComponent<GameControl>().RemoveVisibleFace(faceIndex);
            }
        }
    }

    private void Awake()
    {
        gameControl = GameObject.Find("GameControl");
        meshFilter = GetComponent<MeshFilter>();
        isBack = true;
        meshRenderer = GetComponent<MeshRenderer>();
        isBack = true;
        meshFilter.mesh = back;
        GetComponent<MeshRenderer>().material = backMaterial;
        gameControl.GetComponent<GameControl>().RemoveVisibleFace(faceIndex);
    }

    public void Match(){
        matched = true;
        win = win + 1;
    }

 

}
