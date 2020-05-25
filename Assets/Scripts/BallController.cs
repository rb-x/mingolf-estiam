using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{

    public float zForce = 0;
	
	public GameObject arrowHead;
	public GameObject arrowStem;

    public Camera MainCamera;

    void Start()
    {
        arrowHead = GameObject.Find("arrowHead");
		arrowStem = GameObject.Find("arrowStem");
    }

    void Update()
    {
        if (Input.GetKey("a") && zForce == 0)
        {
            transform.Rotate(0, -2, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && zForce == 0)
        {
            transform.Rotate(0, 2, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && zForce == 0)
        {
            transform.Rotate(0, -2, 0);
        }
        if (Input.GetKey("d") && zForce == 0)
        {
            transform.Rotate(0, 2, 0);
        }
        if (Input.GetKey("r") && zForce == 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            MainCamera.transform.localPosition = new Vector3(0, 6, -8);
            MainCamera.transform.localEulerAngles = new Vector3(25, 0, 0);
        }
        if (Input.GetKey("space"))
        {
            if (GetComponent<Rigidbody>().velocity.z == 0)
            {
                if (zForce < 2250)
                {
                    zForce += 25;
                }
            }
        }
        if (Input.GetKeyUp("space"))
        {
            if (GetComponent<Rigidbody>().velocity.z == 0)
            {
                if (SceneManager.GetActiveScene().name == "hole1")
                {
                    GameManager.hole1 += 1;
                }
                else if (SceneManager.GetActiveScene().name == "hole2")
                {
                    GameManager.hole2 += 1;
                }
                
             
                GameManager.strokes -= 1;
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);
                StartCoroutine(stopball());
            }
        }

        if (GameManager.strokes == 0)
        {
            if(SceneManager.GetActiveScene().name == "hole1") //niv1
            {
                SceneManager.LoadScene("hole2");
				GameManager.strokes = 15;
            }
			else if (SceneManager.GetActiveScene().name == "hole2") // niv 2 final
			{
				SceneManager.LoadScene("End");
				GameManager.strokes = 15;
			}
        }

        arrowHead.GetComponent<MeshRenderer>().enabled = zForce == 0 ? true : false;
		arrowStem.GetComponent<MeshRenderer>().enabled = zForce == 0 ? true : false;
		

        MainCamera.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
    }


    private void OnMouseDrag()
    {
        if (GetComponent<Rigidbody>().velocity.z == 0)
        {
            if (zForce < 2250) {
			    zForce += 25;
		    }
        }
		
    }

    private void OnMouseUp()
    {
        if (GetComponent<Rigidbody>().velocity.z == 0)
        {
            if (SceneManager.GetActiveScene().name == "hole1")
            {
                GameManager.hole1 += 1;
            }
            else if (SceneManager.GetActiveScene().name == "hole2")
            {
                GameManager.hole2 += 1;
            }
             

            GameManager.strokes -= 1;
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);
            StartCoroutine(stopball());
        }
        
    }

    private void OnTriggerEnter(Collider collider)
        // gestion de collision et de sortie de terrain + malus
    {
        if (collider.name == "OutOfBounds")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            if (SceneManager.GetActiveScene().name == "hole1")
            {
                GameManager.hole1 += 3;
                GameManager.strokes -= 3;
            }
            else if (SceneManager.GetActiveScene().name == "hole2")
            {
                GameManager.hole2 += 3;
                GameManager.strokes -= 3;
            }
             
        }
        if (collider.name == "cup1")
        {
            SceneManager.LoadScene("hole2");
			GameManager.strokes = 15;
        }
		else if (collider.name == "cup2")
		{
			SceneManager.LoadScene("End");
			GameManager.strokes = 15;
		}
    }

    IEnumerator stopball()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        transform.localEulerAngles = new Vector3(0, 0, 0);
		MainCamera.transform.localPosition = new Vector3(0, 6, -8);
		MainCamera.transform.localEulerAngles = new Vector3(25, 0, 0);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        zForce = 0;

    }
	
	void OnGUI()
    {
        //affichage puissance in game
        GUI.Box(new Rect((Screen.width / 2) - Screen.width / 20, Screen.height / 1.1f, Screen.width / 10, Screen.height / 15), "Force : " + zForce);
    }
}
