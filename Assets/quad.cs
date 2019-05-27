using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quad : MonoBehaviour {




    bool check = false;
    GameObject obj;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "EditorOnly" && collision.gameObject.tag != "Respawn" && collision.gameObject.name == "Domino (7)")
        {
            Debug.Log("gameobject i = " + gameObject.name);
            Debug.Log("Collisioning = " + collision.gameObject.name);
            obj = collision.gameObject;
            StartCoroutine(Example());
        }
    }
    IEnumerator Example()
    {

        yield return new WaitForSeconds(.5f);
        obj.SetActive(false);
    }
}
