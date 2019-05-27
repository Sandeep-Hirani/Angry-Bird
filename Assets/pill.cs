using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pill : MonoBehaviour {

    bool check = false;
    GameObject obj;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "EditorOnly" && collision.gameObject.tag != "Respawn" && !check)
        {

            //Destroy(collision.gameObject);
            Debug.Log("gameobject i = " + gameObject.name);
                Debug.Log("Collisioning = "   +collision.gameObject.name);
            StartCoroutine(Example());
            obj = collision.gameObject;
            check = true;
        }
    }
    IEnumerator Example()
    {
       
        yield return new WaitForSeconds(.1f);
        obj.SetActive(false);
      
    }

}
