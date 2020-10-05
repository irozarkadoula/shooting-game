using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToShoot : MonoBehaviour
{
    
    public float score;
    public bool end_game;
    private int width, height;
    static float timer;
    

    void Awake()
    {
        
        
    }
    void Start()
    {
		score = 0;
        end_game = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        width = Screen.width;
        height = Screen.height;
        timer += Time.deltaTime;
    }
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            score = score + 1; 
			if (score == 5){
                end_game = true;
            }
        }
    }
	 void OnGUI()
    {
        
        GUIStyle labelDetails = new GUIStyle(GUI.skin.GetStyle("label"));

        GUIStyle labelDetailsTime = new GUIStyle(GUI.skin.GetStyle("label"));

        if(width < height)
        {
            labelDetailsTime.fontSize = 12 * (width / 200);
            labelDetails.fontSize = 14 * (width / 200);

            GUI.Label(new Rect(width / 8, height / 8, width - (2 * width / 8), height - (2 * height / 4)),
                "Score: " + score + "/5", labelDetails);
            GUI.Label(new Rect(width / 3, height / 12, width - (2 * width / 8), height - (2 * height / 8)),
                   "Time: " + TimeFormat(timer), labelDetailsTime);
        }
        else
        {
            labelDetailsTime.fontSize = 6 * (width / 200);
            labelDetails.fontSize = 8 * (width / 200);

            GUI.Label(new Rect(width / 4, height / 8, width - (2* width/ 8), height - (7 * height / 8)),
                "Score: " + score + "/5", labelDetails);
            GUI.Label(new Rect(width / 2.5f, height / 20, width - (2*width / 8), height- (7 * height / 8)),
                   "Time: " + TimeFormat(timer), labelDetailsTime);
        }


        if (end_game) {
           
            Application.LoadLevel("fireworks");
            
        }
      
    }
    string TimeFormat(float timeformat)
    {
        int d = (int)(timeformat * 100.0f);
        int seconds = d / 100;
        int hundredths = d % 100;
        return string.Format("{0:00}.{1:00}", seconds, hundredths);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("time", timer);
    }
}
