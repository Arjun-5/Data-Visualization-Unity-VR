using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider sceneTransfer;
    private string currentSceneName;
    void Start()
    {
        sceneTransfer=GetComponent<BoxCollider>();
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {      
        if(currentSceneName == "NatureEnvironment" && other.tag == "MainPlayer")
        {
            SceneManager.LoadScene("BusinessEnvironment");
        }
        if(currentSceneName =="BusinessEnvironment" && other.tag == "MainPlayer")
        {
            SceneManager.LoadScene("NatureEnvironment");
        }
        
    }
}
