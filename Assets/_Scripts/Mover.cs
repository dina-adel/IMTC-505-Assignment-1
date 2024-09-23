using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject trail;        // only this needs to be public
    private float speed;            // speed of the cube
    private Renderer cubeRenderer;      // renderer to change cube color
    private float trailTimer;           // timer for appearing trail
    private Vector3 movement;           // cube movement vector
    
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        trailTimer = 0f; // start the trail timer
        speed = 0.5f;   // default speed of 0.5

    }

    // Update is called once per frame
    void Update()
    {
       float moveHorizontal = Input.GetAxis("Horizontal"); // read A and D for left and right       
       float moveVertical = Input.GetAxis("Vertical");     // read W and S for forward and backward
       
       // increment timer 
       trailTimer += Time.deltaTime;    
       
       // move the cube in a specific or default
       MoveCube(moveVertical, moveHorizontal);
       
       // create the trail to appear every second
       if (trailTimer > 1f)  CreateDisappearingTrail(); 
       
       // if a space is clicked, change the color of the cube to a random color
       if (Input.GetKeyDown(KeyCode.Space))  ChangeCubeColor();       
       
    }
    
    void MoveCube(float moveVertical, float moveHorizontal)
        {   /*  Move the cube in a specific or default direction
                inputs:
                    * moveVertical (float): the W/S movement reading
                    * moveHorizontal (float): the A/D movement reading
            */
            
            // check whether WASD were used or use a default movemnet
            if (moveVertical != 0 || moveHorizontal != 0) 
            { movement = new Vector3(moveHorizontal, 0, moveVertical); 
            } else { movement = new Vector3(0.5f, 0, 0);}    // default movement  
             
            // move the Cube
            this.gameObject.transform.position += Time.deltaTime * speed * movement;    
        }
    
    void CreateDisappearingTrail()
    {   /* Create a Trail of disappearing cubes. 
            The cubes appear every second and disappear every 10 seconds.
            They also have a random color each time.                                                     
        */
        
        // create a trail instance in the current cube's location
        GameObject trailInstance = Instantiate(trail, this.gameObject.transform.position, Quaternion.identity);
        
        // render and choose a random color for the new trail 
        Renderer trailRenderer = trailInstance.GetComponent<Renderer>();  
        trailRenderer.material.color = new Color(Random.value, Random.value, Random.value);

        // destroy trail instance after 10 secs and reset the trail timer
        Destroy(trailInstance, 10f);  
        trailTimer = 0f;
    }
    
    void ChangeCubeColor()
    {   /* Change the Cube color to a random color */
        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);
         }
     }
    
}
