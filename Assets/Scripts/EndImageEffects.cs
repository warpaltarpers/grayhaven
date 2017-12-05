using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

public class EndImageEffects : MonoBehaviour {

    public GameObject playerCamera;

    public GameObject[] TheEndLine1;
    /*public GameObject TheEndLine2;
    public GameObject TheEndLine3;
    public GameObject TheEndLine4;
    public GameObject TheEndLine5;
    public GameObject TheEndLine6;*/


    public Animator Anim;

    bool Triggered;

    static float t = 0.0f;
    float currentFoV;

    void Start()
    {
        for (int i = 0; i < TheEndLine1.Length; i++)
        {
            TheEndLine1[i].SetActive(false);
            
        }
    }
    void OnTriggerEnter2D()
    {

        

        gameObject.GetComponent<Animator>().enabled = true;

        StartCoroutine(ToTitleAgain());

        // playerCamera.camera.
        //Camera.main.fieldOfView = Mathf.Lerp(100, 110, t);
        Triggered = true;




    }

    void Update()
    { 
        if (Triggered)
        {
            currentFoV = Camera.main.fieldOfView;
            Camera.main.fieldOfView = Mathf.Lerp(currentFoV, 130, 2 * Time.deltaTime);
        }
    }
    IEnumerator ToTitleAgain()
    {
        yield return new WaitForSeconds(2);
        Anim.SetTrigger("bossTrigger");
        yield return new WaitForSeconds(3);
        //TheEndCanvas.SetActive(true);
        for(int i = 0; i < TheEndLine1.Length; i++)
        {
            TheEndLine1[i].SetActive(true);
            yield return new WaitForSeconds(3);
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("TitleScreen");
    }




}
