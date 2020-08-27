using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private init initScript;
    public Text lose;
    public GameObject myCanvas;
    void Start()
    {
       
        initScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<init>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (initScript.listMap.Count >= 3)
        {
            //Destroy(initScript.listMap[0]);
            initScript.listMap.RemoveAt(0);
            initScript.generateMap();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("penghalang"))
        {
            lose.text = "YOU LOSE!!";
            initScript.isPlayed = false;
            myCanvas.SetActive(true);

        }
    }


}
