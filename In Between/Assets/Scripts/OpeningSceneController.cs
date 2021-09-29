using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSceneController : MonoBehaviour
{
    public GameObject ragdoll1;
    public GameObject grate1;
    public GameObject spawn1;

    void Start()
    {
        StartCoroutine(openScene());
    }

    IEnumerator openScene()
    {
        yield return new WaitForSeconds(5f);

        grate1.GetComponent<Rigidbody>().isKinematic = false;

        yield return new WaitForSeconds(.1f);

        Instantiate(ragdoll1, spawn1.transform.position, spawn1.transform.rotation);
    }
}
