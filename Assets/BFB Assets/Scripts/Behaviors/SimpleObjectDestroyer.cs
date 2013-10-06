using UnityEngine;
using System.Collections;

public class SimpleObjectDestroyer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyObject(GameObject collidedObject)
    {
        Destroy(gameObject);
    }
}
