using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        GetComponent<XRSimpleInteractable>().interactionManager = FindObjectOfType<XRInteractionManager>();
    }

    void Update()
    {        
        transform.Translate(transform.forward * Time.deltaTime * speed,
            Space.World);
        if (transform.position.z <= Camera.main.transform.position.z)
        {
            FindObjectOfType<GameManager>().EndLife();
        }
    }
	
    public void OnSelected()
    {
        GameManager.score++;
        Debug.Log(GameManager.score);
        Destroy(gameObject);		
    }
	
	
	
	
}