using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class init : MonoBehaviour
{
    private GameObject myCharacter;
    public Text point;
    public GameObject myCamera;
    public List<GameObject> myMap;
    public GameObject myIdleCharacter;
    public GameObject myWalkCharacter;
    public GameObject myCanvas;
    public Animator myAnimator;
    public List<GameObject> listMap = new List<GameObject>();
    private float baseRun = 0.04f;
    private float baseJump = 2;
    public bool isPlayed = false;
    public void play()
    {
        myCharacter = myIdleCharacter;
        this.isPlayed = true;
        myCanvas.SetActive(!isPlayed);
        myIdleCharacter.SetActive(!isPlayed);
        myWalkCharacter.SetActive(isPlayed);
        myIdleCharacter = myWalkCharacter;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        listMap.Add(myMap[0]);
        generateMap();
        generateMap();
        generateMap();
        
    }

    IEnumerator addSpeed()
    {
        yield return new WaitForSeconds(1);
        AnimatorStateInfo info  = myAnimator.GetCurrentAnimatorStateInfo(0);
        int currentPoint = Int32.Parse(point.text) + 1;
        point.text = currentPoint.ToString();
        //Debug.Log(baseRun);
        if (baseRun <= 0.2f){
            baseRun += 0.005f;
			myAnimator.speed += 0.1f;
		}
       
        StopAllCoroutines();
    }

    public void generateMap()
    {
        var rand = new System.Random();
        Int32 hwe = rand.Next(0, myMap.Count);
        GameObject newMap = Instantiate(myMap[hwe], new Vector3(listMap[listMap.Count - 1].transform.position.x + 20, listMap[listMap.Count - 1].transform.position.y, listMap[listMap.Count - 1].transform.position.z), new Quaternion());
        listMap.Add(newMap);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPlayed = (isPlayed == false) ? true : false;
            if(isPlayed == false)
            {
                myCanvas.SetActive(true);
            }
            else
            {
                myCanvas.SetActive(false);
            }
        }
        if (isPlayed)
        {
            myWalkCharacter.transform.position = new Vector3(myWalkCharacter.transform.position.x+baseRun, myWalkCharacter.transform.position.y, myWalkCharacter.transform.position.z);
            myCamera.transform.position = new Vector3(myCamera.transform.position.x + baseRun , myCamera.transform.position.y , myCamera.transform.position.z);
            Coroutine runningCoroutine =  StartCoroutine(addSpeed());
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(myWalkCharacter.transform.position.y <= 3)
                    myWalkCharacter.transform.position = new Vector3(myWalkCharacter.transform.position.x,myWalkCharacter.transform.position.y+baseJump,myWalkCharacter.transform.position.z);
            }
        }   
    }

    

}
