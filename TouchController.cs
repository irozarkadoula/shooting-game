using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TouchController : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform spawnObject;
    public AudioClip[] aClips;
    public AudioSource myAudioSource;
    public Image powerbar;
    public Rigidbody rb;
    public float waitTime = 0.1f;
    private bool uncompleted = true;
    private bool touched = false;
    string btnName;
    private int width, height;
    float tries;
    float Volume;// 
    float FSource;
    void Awake()
    {
    }
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        tries = 0;
        FSource = 100;

    
    }
    // Update is called once per frame
    
    void FixedUpdate()
    {
        powerbar.transform.position = new Vector3(width - (2 * width / 8), height - (7.5f * height / 8), 0);
    }

    void Update()
    {

        width = Screen.width;
        height = Screen.height;

        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                btnName = Hit.transform.name;
                switch (btnName)
                {
                    case "Sphere":
                        touched = true;
                        if (uncompleted)
                        {
                            powerbar.fillAmount += 7.0f / waitTime * Time.deltaTime;
                            if (powerbar.fillAmount > 0.99f)
                            {

                                uncompleted = false;
                            }

                        }
                        else
                        {
                            powerbar.fillAmount -= 7.0f / waitTime * Time.deltaTime;
                            if (powerbar.fillAmount < 0.01f)
                            {
                                uncompleted = true;

                            }
                        }
                        if (Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                        }
                        if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        {
                            FSource = powerbar.fillAmount;
                            FSource = FSource * 300;
                            GameObject go = Instantiate(bulletprefab, spawnObject.position, spawnObject.rotation) as GameObject;
                            rb = go.GetComponent<Rigidbody>();
                            go.GetComponent<Rigidbody>().AddForce(transform.forward * FSource, ForceMode.Impulse);
                            myAudioSource.clip = aClips[0];
                            myAudioSource.Play();
                            tries += 1;
                            powerbar.fillAmount = 0;

                            uncompleted = true;
                            touched = false;

                        }
                        break;
                    default:
                        break;
                }
            }
           
        
        }
    }
    
    void OnGUI()
    {
        GUIStyle labelDetails = new GUIStyle(GUI.skin.GetStyle("label"));

        if (width < height)

        {
            labelDetails.fontSize = 14 * (width / 200);
            GUI.Label(new Rect(6 * width / 10, height / 8, width - (2 * width / 8), height - (2 * height / 4)),
            "Tries: " + tries, labelDetails);
        }
        else
        {
            labelDetails.fontSize = 8 * (width / 200);
            GUI.Label(new Rect(6 * width / 10, height / 8, width - (2 * width / 8), height - (7 * height / 8)),
            "Tries: " + tries, labelDetails);
        }
        if (touched)
        {


            if (width < height)
            {
                GUI.Label(new Rect(6 * width / 10, 7 * height / 8, width - (2 * width / 8), height - (7 * height / 8)), "Powerbar", labelDetails);

            }
            else
            {
                GUI.Label(new Rect(6.5f * width / 10, 6.5f * height / 8, width - (2 * width / 8), height - (7 * height / 8)), "Powerbar", labelDetails);

            }
        }

    }
}