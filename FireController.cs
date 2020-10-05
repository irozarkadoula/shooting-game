using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FireController : MonoBehaviour
{
    private int width, height;
	public Texture2D success;
    public Texture2D fail;

    private float playerTime;
    private bool pressed;


    void Awake()
    {


    }
	void Start(){
		
	}

    void OnGUI()
    {

        GUIStyle labelDetailsButton = new GUIStyle(GUI.skin.GetStyle("button"));
        GUIStyle labelDetailsLabel = new GUIStyle(GUI.skin.GetStyle("label"));
        GUIStyle labelDetailsIcon = new GUIStyle(GUI.skin.GetStyle("label"));
        GUIStyle labelDetailsMessage = new GUIStyle(GUI.skin.GetStyle("label"));

        Color red = new Color(0.7f, 0.1f, 0.1f, 0.8f);
        Color darkgreen = new Color(0, 0.4f, 0, 0.8f);
       
        Color bordercolor = new Color();
        labelDetailsButton.fontSize = 16 * (width / 200);
        labelDetailsLabel.fontSize = 14 * (width / 200);
        labelDetailsMessage.fontSize = 30 * (width / 200);
        labelDetailsMessage.fontStyle = FontStyle.Bold;

        labelDetailsLabel.padding.left = width / 5;
        labelDetailsLabel.padding.top = Mathf.RoundToInt(1.15f * height / 2);


        labelDetailsMessage.normal.background = Texture2D.whiteTexture;
        GUI.backgroundColor = Color.white;
        labelDetailsLabel.normal.textColor = Color.gray;
        labelDetailsMessage.normal.textColor = Color.black;

        labelDetailsMessage.alignment = TextAnchor.MiddleCenter;




        if (playerTime < 60)
        {
            bordercolor = darkgreen;
       
            labelDetailsIcon.normal.background = success;

            labelDetailsButton.normal.textColor = darkgreen;

            GUI.Label(new Rect(0, 0, width , height ),
          " yay! ", labelDetailsMessage);

        }
        else
        {
            bordercolor = red;

            labelDetailsIcon.normal.background = fail;

            labelDetailsButton.normal.textColor = red;

            GUI.Label(new Rect(0, 0, width, height),
        " uh-oh.. ", labelDetailsMessage);
        }

        Texture2D texture = new Texture2D(width / 2, Mathf.RoundToInt(0.5f * height / 4), TextureFormat.ARGB32, false);
        for (int y = 0; y < texture.height; y++)
        {
            if (y <= 8 || y >= texture.height - 8)
            {
                for (int x = 0; x < texture.width; x++)
                {

                    texture.SetPixel(x, y, bordercolor);
                }
            }
            else
            {

                for (int x = 0; x < texture.width; x++)
                {
                    texture.SetPixel(x, y, Color.white);
                }
            }
        }

        for (int x = 0; x < texture.width; x++)
        {
            if (x <= 6 || x >= texture.width - 6)
            {
                for (int y = 0; y < texture.height; y++)
                {

                    texture.SetPixel(x, y, bordercolor);
                }

            }
        }
        texture.Apply();
        labelDetailsButton.normal.background = texture;

        GUI.Label(new Rect(0,0, width, height ),
              " Completion Time: " + TimeFormat(playerTime), labelDetailsLabel);

        GUI.Label(new Rect(width/3, 2*height/8, 256, 256),
      "", labelDetailsIcon);

        
        pressed = GUI.Button(new Rect(width / 4, 2*height / 3, width - (2 * width / 4), height - (3.5f * height / 4)),
            "Restart Game", labelDetailsButton);


        if (pressed)
        {

            Application.LoadLevel( "moya" );
		}
		
    }


    string TimeFormat(float timeformat)
    {
        int d = (int)(timeformat * 100.0f);
        int seconds = d / 100;
        int hundredths = d % 100;
        return string.Format("{0:00}.{1:00}", seconds, hundredths);
    }

    // Update is called once per frame
    void Update()
    {

        width = Screen.width;
        height = Screen.height;
    }

    void OnEnable()
    {
        playerTime = PlayerPrefs.GetFloat("time");
    }

}
