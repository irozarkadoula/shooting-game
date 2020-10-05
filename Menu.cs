using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    private int width, height;
	public Texture2D background;
    private bool pressed;
	void Awake()
    {
       
    }
	void Start(){
		
	} 
	void OnGUI()
    {
		
		GUIStyle labelDetailsButton = new GUIStyle(GUI.skin.GetStyle("button"));

        GUIStyle labelDetailsLabel = new GUIStyle(GUI.skin.GetStyle("button"));


        labelDetailsButton.fontSize = 14 * (width / 200);
		if(background != null){
            labelDetailsLabel.normal.background = Texture2D.whiteTexture;

        }

        pressed = GUI.Button(new Rect(width / 4, height / 2, width - (2 * width / 4), height - (3.5f * height / 4)),
            "Enter Game", labelDetailsButton);
            

        if (pressed)
        {

                 Application.LoadLevel( "moya" );
		}
    }
// Update is called once per frame
    void Update()
    {

        width = Screen.width;
        height = Screen.height;
    }
    
   
}
