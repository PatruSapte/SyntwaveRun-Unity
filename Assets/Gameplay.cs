using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gameplay : MonoBehaviour
{
    public GameObject tesaract,tepi, menu;
    int score=0;
    public TextMeshProUGUI scoreText;
    public Rigidbody rb;
    bool gameplaying;
    public Vector3 lastSurfacePosition;
    private void Start()
    {
        gameplaying = true;
        StartCoroutine(AddScore());
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemy")
        {
            GameOver();
        }    
        if(other.tag=="points")
        {
            AddPoints(other.gameObject);
        }
        if (other.tag == "surface")
        {
            MoveSurface(other.transform);
        }
    }

    public void GameOver()
    {
        gameplaying = false;
        rb.AddForce(transform.up*50,ForceMode.VelocityChange);
        rb.AddTorque(120, 400, 200,ForceMode.VelocityChange);
        menu.SetActive(true);
    }
    public void AddPoints(GameObject obj)
    {
        score += Random.Range(10, 100);
        Destroy(obj);
    }

    public void MoveSurface(Transform surface)
    {
        surface.localPosition +=  Vector3.forward*148f*3;
        int nrOfTesaract = Random.Range(1,10);
        int nrOfTepi = Random.Range(1, 5);

        Vector3 poz = new Vector3();
        poz.y = 0;
        for (int i = 0; i < nrOfTepi; i++)
        {
            poz.x = Random.Range(-6, 36);
            poz.z = Random.Range(-70, 70);
            GameObject tep = Instantiate(tepi, surface.GetChild(0).position + poz, Quaternion.identity);
            tep.transform.parent = null;
            tep.transform.localScale = Random.Range(0.2f,2f) * Vector3.one;
        }


        for (int i = 0; i < nrOfTesaract; i++)
        {
            poz.x = Random.Range(-6, 36);
            poz.z = Random.Range(-70, 70);
            poz.y = Random.Range(1f, 2f);
            Instantiate(tesaract, surface.GetChild(0).position + poz, Quaternion.identity);
            
        }
    }
    IEnumerator AddScore()  
    {
        while (gameplaying)
        {
            score += (int)(rb.velocity.magnitude/30f);
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }


}
