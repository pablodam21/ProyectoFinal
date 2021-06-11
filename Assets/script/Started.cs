using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Started : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void StartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
		
	}
	
	public void CloseGame()
	{
		Application.Quit();
	}

	public void OptionsGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}

