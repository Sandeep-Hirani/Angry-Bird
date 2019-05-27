using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sphere : MonoBehaviour {

    public Rigidbody2D rb;
    public float tr = 5f;
    private bool isPressed = false;
    public GameObject player;
    private Vector3 offset;
    public static bool move = false;
    public GameObject[] players;
    public GameObject[] secondTower;
    public GameObject[] Domino;
    private GameObject firstDomino;
    private GameObject topball;
    private GameObject FirstTopBall;
    public static bool stopCamera = false;
    public static bool dominochange = false;
    private float[] domArr;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("stands");
        secondTower = GameObject.FindGameObjectsWithTag("building");
        topball = GameObject.Find("Sphere (5)");
        FirstTopBall = GameObject.Find("Sphere (6)");
        Domino = new GameObject[] { GameObject.Find("Domino"), GameObject.Find("Domino (1)"), GameObject.Find("Domino (2)"),
        GameObject.Find("Domino (3)"),GameObject.Find("Domino (4)"),GameObject.Find("Domino (5)"),GameObject.Find("Domino (6)"),
        GameObject.Find("Domino (7)")};
       // Domino = GameObject.FindGameObjectsWithTag("domino");
        firstDomino = GameObject.Find("Domino (1)");
        float x = 34.96f;
        domArr = new float[8] { x,x+1,x+2.25f,x+3.75f,x+5.5f, x+7.5f,x+9.75f,x+12.5f};
    }



    string prevObject = "";
    void camerachange(GameObject[] game)
    {

        GameObject g = calculate(game);
        cameraMovement.player = g;
        if (prevObject != g.name)
        {
            cameraMovement.callfunc = true;
        }
        prevObject = g.name;
        //Debug.Log(g.name);
       
    }

    GameObject calculate(GameObject[] play)
    {
        GameObject x = play[0];
        float xdis = x.transform.position.x;
        for (int i = 1; i < play.Length; i++)
        {
            if (xdis < play[i].transform.position.x)
            {
                x = play[i];
                xdis = x.transform.position.x;
            }
        }
        return x;
    }
    int x = 0;
    void Update()
    {
        if(FirstTopBall.transform.position.x != 20.44f && topball.transform.position.x == 26f)
        {
            camerachange(players);
        }
        if(topball.transform.position.x != 26f && firstDomino.transform.position.x ==35.96f)
        {
            camerachange(secondTower);
        }
        for (int i = x; i < Domino.Length; i++)
        {
            if (Domino[i].transform.position.x != domArr[i])
            {
                cameraMovement.player = Domino[i];
                cameraMovement.callfunc = true;

                x++;
            }
        }
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        move = true;
        StartCoroutine(LetSpringGo());

    }

    IEnumerator LetSpringGo()
    {
        yield return new WaitForSeconds(tr);
        GetComponent<SpringJoint2D>().enabled = false;
    }
}
