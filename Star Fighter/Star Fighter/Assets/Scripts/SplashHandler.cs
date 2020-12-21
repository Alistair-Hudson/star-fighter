using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashHandler : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        FindObjectOfType<SceneHandler>().LoadNextScene();
    }
}
