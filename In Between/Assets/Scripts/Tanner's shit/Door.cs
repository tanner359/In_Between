using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneName;

    public void Travel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
